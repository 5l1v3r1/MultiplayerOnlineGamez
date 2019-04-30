using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Permissions;

//PORT IS 219

namespace ERSCardGame
{
	public partial class Form1 : Form
	{
		public static Thread recthread;
		public Form1()
		{
			InitializeComponent();
			Log("Connecting");
			recthread = new Thread(new ThreadStart(RecieveThread));
			recthread.Start();
		}

		bool ShownConnectMessage = false;

		private void LoopConnect()
		{
			int attempts = 0;
			while (!ClientSocket.Connected && attempts < 10)
			{
				attempts++;
				try
				{
					ClientSocket.Connect(IPAddress.Loopback, 219);
				}
				catch (Exception e)
				{
					Log("Error Occured: " + e.GetType().ToString() + ": " + e.Message);
					Log("Connection Attempt: " + attempts);
				}
				Update();
			}
			if (ShownConnectMessage)
			{
				return;
			}
			if (ClientSocket.Connected && !ShownConnectMessage)
			{
				Log("Connected!");
				ShownConnectMessage = true;
			}
			else
			{
				Log("Could not connect to server!\nExiting! (Servers may be down, your firewall is blocking it, or your ISP is blocking the server!)", true);
				Application.Exit();
			}
		}

		public Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		public Thread Recthread { get => recthread; set => recthread = value; }
		public Thread Recthread1 { get => recthread; set => recthread = value; }
		public bool Exiting { get; private set; }
		public bool Restarting { get; private set; }

		private void Form1_Shown(object sender, EventArgs e)
		{
			logtext.Text = "Please enter name to continue...";
		}

		private void Log(string text, bool msgbox)
		{
			if (msgbox)
			{
				MessageBox.Show(text, "ERS Card Game", MessageBoxButtons.OK);
			}
			Console.WriteLine(text);
			string update = logtext.Text + "\n" + text;
			logtext.Text = update;
		}

		private void Log(string text)
		{
			Console.WriteLine(text);
			string update = logtext.Text + "\n" + text;
			logtext.Text = update;
		}

		private void Send(string text)
		{
			ClientSocket.Send(Encoding.ASCII.GetBytes(text));
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (ClientSocket.Connected)
			{
				logtext.Text = logtext.Text == "Please enter name to continue..." ? string.Empty : logtext.Text;
				if (e.KeyCode == Keys.L)
				{
					logtext.Visible = logtext.Visible ? false : true;
				}
				if (e.KeyCode == Keys.Space)
				{
					Send(namebox.Text + "\nslapped");
				}
			}
			else
			{
				logtext.Text = "Please enter name to continue...";
			}
		}
			
		private void RecieveThread()
		{
			while (true)
			{
				Thread.Sleep(1);
				if (ClientSocket.Connected)
				{
					byte[] recbuf = new byte[1024];
					int rec = ClientSocket.Receive(recbuf);
					byte[] data = new byte[rec];
					Array.Copy(recbuf, data, rec);
					Log("Recieved: " + Encoding.ASCII.GetString(data));
					if (Encoding.ASCII.GetString(data) == "NAMEEXISTS")
					{
						Send("ERR-NAMEEXISTS...ACTION.DISCONNECT_SOCKET...CODE 0X01");
						Log("NAME ALREADY EXISTS! EXITING!", true);
						Thread.Sleep(1000);
						BeginExit(false);
						ClientSocket.Disconnect(false);
						ClientSocket.Dispose();
					}
				}
			}
		}

		private void BeginExit(bool restart)
		{
			Exiting = true;
			Restarting = restart;
		}

		private void Exit()
		{
			KillRecThread();
			if (!Restarting)
			{
				Application.Exit();
			}
			else
			{
				Application.Restart();
			}
		}

		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		private void KillRecThread() => recthread.Abort();

		private void Sendname_Click(object sender, EventArgs e)
		{
			if (!ClientSocket.Connected)
			{
				namegroupbox.Visible = false;
				sendname.Enabled = false;
				LoopConnect();
				Send(namebox.Text);
				slapbutton.Select();
				slapbutton.Enabled = true;
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
			KillRecThread();
		}

		private void Slapbutton_Click(object sender, EventArgs e) => Send(namebox.Text + "\nslapped");

		private void Exittester_Tick(object sender, EventArgs e)
		{
			if (Exiting == true)
			{
				Exit();
			}
		}
	}
}