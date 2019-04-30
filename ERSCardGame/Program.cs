﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERSCardGame
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			KillRecThread();

		}
		[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
		static void KillRecThread()
		{
			Form1.recthread.Abort();
		}
	}
}
