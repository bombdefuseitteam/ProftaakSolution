using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClientTester
{
    class SocketConnection : Common
    {
        UdpClient socketClient = new UdpClient();
        IPEndPoint ep2 = new IPEndPoint(IPAddress.Any, 1337);

        /// <summary>
        /// Open connection to TCP Socket Server.
        /// </summary>
        internal void InitializeConnection()
        {
                ReceiveMessage();
            socketClient.Connect(ep2);
        }

        /// <summary>
        /// Send a packet to the TCP Socket Server
        /// </summary>
        /// <param name="output"></param>


        /// <summary>
        /// Creates a receiving stream, this receives any packets sent from the server.
        /// </summary>
        void ReceiveMessage()
        {
            while (true)
            {
                socketClient.Client.Bind(new IPEndPoint(IPAddress.Any, 11000));
                byte[] connection = socketClient.Receive(ref ep2);
                string returnData = Encoding.ASCII.GetString(connection);

                ///Checks if count is at least > 0 before confirming a received packet.
                if (returnData.Length > 0)
                {
                    Print("RECEIVED: " + returnData);
                    Print("Sending Received Response", true, true, ConsoleColor.Yellow);
                }
            }
        }
    }
}
