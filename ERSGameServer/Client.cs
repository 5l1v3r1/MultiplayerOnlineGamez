using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ERSGameServer
{
	class Client
	{
		public Socket socket = null;

		public string name = "";

		public Client(Socket soc)
		{
			socket = soc;
		}

		public void SetName(string data)
		{
			name = data;
		}
	}
}
