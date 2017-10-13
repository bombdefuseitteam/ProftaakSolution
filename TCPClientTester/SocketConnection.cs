using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClientTester
{
    class SocketConnection : Common
    {
        TcpClient socketClient = new TcpClient();
        NetworkStream globalStream;
        string ipAdress = "127.0.0.1";
        int port = 5555;

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

        void SendMessage(string output)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(output);
            globalStream.Write(outStream, 0, outStream.Length);
        }

        void ReceiveMessage()
        {
            while (socketClient.Connected)
            {
                byte[] inStream = new byte[10025];
                globalStream = socketClient.GetStream();
                var count = globalStream.Read(inStream, 0, inStream.Length);
                var returnData = Encoding.ASCII.GetString(inStream, 0, count);

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
