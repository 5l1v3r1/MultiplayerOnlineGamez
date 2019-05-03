using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using ERSGameServer;
using Techcraft7_DLL_Pack;

namespace ERSGameServer
{
	using static ColorConsoleMethods;
	using static Console;
	class Program
	{
		private static byte[] Buffer = new byte[1024];
		private static List<Client> Clients = new List<Client>();
		private static Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		private static string LastCopiedName = "";
		static void Main(string[] args)
		{
			SetupServer();
			Read();
		}

		private static void SetupServer()
		{
			WriteLineColor("Setup starting...", ConsoleColor.Magenta);
			WriteLineColor("Done!", ConsoleColor.Green);
			ServerSocket.Bind(new IPEndPoint(IPAddress.Any, 219));
			ServerSocket.Listen(15);
			ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}

		private static void AcceptCallback(IAsyncResult AR)
		{
			Socket socket = ServerSocket.EndAccept(AR);
			Client client = new Client(socket);
			//set name
			byte[] recbuf = new byte[1024];
			int rec = socket.Receive(recbuf);
			byte[] data = new byte[rec];
			Array.Copy(recbuf, data, rec);
			client.SetName(Encoding.ASCII.GetString(data));
			//add client
			if (!DoesNameExist(Encoding.ASCII.GetString(data)))
			{
				Clients.Add(client);
			}
			else
			{
				client.socket.Send(Encoding.ASCII.GetBytes("NAMEEXISTS"));
				WriteLineColor(string.Format("Client tried to set the name to the exisiting name {0}... Telling client to disconnect and exit...", LastCopiedName), ConsoleColor.Red);
				return;
			}
			WriteLineColor("Client Connected!", ConsoleColor.Green);
			SendData("Your client has been binded to the name: " + client.name, socket);
			socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);
			ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}

		private static bool DoesNameExist(string name)
		{
			foreach (Client i in Clients)
			{
				if (i.name == name)
				{
					LastCopiedName = name;
					return true;
				}
			}

			return false;
		}

		private static void RecieveCallback(IAsyncResult AR)
		{
			int recieved = 0;
			Socket socket = (Socket)AR.AsyncState;
			try
			{
				recieved = socket.EndReceive(AR);
			}
			catch (Exception e)
			{
				if (e.Message == "An existing connection was forcibly closed by the remote host")
				{
					WriteLineColor("A user disconnected!", ConsoleColor.Red);
				}
			}
			byte[] DataBuf = new byte[recieved];
			Array.Copy(Buffer, DataBuf, recieved);
			string text = Encoding.ASCII.GetString(DataBuf);
			if (text == "ERR-NAMEEXISTS... ACTION.DISCONNECT_SOCKET... CODE 0X01")
			{
				WriteLineColor("Client Error: " + text, ConsoleColor.Red);
				return;
			}
			WriteLineColor("Recieved data from client: " + text, ConsoleColor.Yellow);

			ParseGameData(text, socket);
		}

		private static void ParseGameData(string text, Socket socket)
		{
			Client client = null;
			string user, data = string.Empty;
			user = text.Split('\n')[0];
			data = text.Split('\n')[1];
			//identify client
			foreach (Client c in Clients)
			{
				if (c.name == user)
				{
					client = c;
				}
			}
			//parse data
		}

		private static void SendData(string data, Socket socket)
		{
			byte[] DataBytes = Encoding.ASCII.GetBytes(data);
			socket.BeginSend(DataBytes, 0, DataBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
		}

		private static void SendCallback(IAsyncResult AR)
		{
			Socket socket = (Socket)AR.AsyncState;
			socket.EndSend(AR);
		}
	}
}
