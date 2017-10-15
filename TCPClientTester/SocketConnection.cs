using System;
using System.Net.Sockets;
using System.Text;

namespace TCPClientTester
{
    class SocketConnection : Common
    {
        TcpClient socketClient = new TcpClient();
        NetworkStream globalStream;

        ///Server Info
        string ipAdress = "127.0.0.1";
        int port = 5555;

        /// <summary>
        /// Open connection to TCP Socket Server.
        /// </summary>
        internal void InitializeConnection()
        {
            try
            {
                Print("Attempting to connect to TCP Server: " + ipAdress + ":" + port, true);
                socketClient.Connect(ipAdress, port);
                Print("Connected!", true, true, ConsoleColor.Green);
                ReceiveMessage();

            }
            catch (Exception e)
            {

                Print("Connection Timeout!", true, true, ConsoleColor.Red);
                Print(e.ToString());
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Send a packet to the TCP Socket Server
        /// </summary>
        /// <param name="output"></param>
        void SendMessage(string output)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(output);
            globalStream.Write(outStream, 0, outStream.Length);
        }

        /// <summary>
        /// Creates a receiving stream, this receives any packets sent from the server.
        /// </summary>
        void ReceiveMessage()
        {
            while (socketClient.Connected)
            {
                byte[] inStream = new byte[10025];
                globalStream = socketClient.GetStream();
                var count = globalStream.Read(inStream, 0, inStream.Length);
                var returnData = Encoding.ASCII.GetString(inStream, 0, count);

                ///Checks if count is at least > 0 before confirming a received packet.
                if (count > 0)
                {
                    Print("RECEIVED: " + returnData);
                    count = 0;
                    Print("Sending Received Response", true, true, ConsoleColor.Yellow);
                    SendMessage("I've received your TCP packet");
                }
            }
        }
    }
}
