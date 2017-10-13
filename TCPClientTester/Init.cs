using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientTester
{
    class Init
    {
        //Initialize SocketConnection
        static void Main(string[] args)
        {
            SocketConnection tcpClient = new SocketConnection();
            tcpClient.InitializeConnection();
        }
    }
}
