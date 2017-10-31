using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;
using DefuseIT_Game.GameEvents;
using DefuseIT_Game.SQL;
using System.ComponentModel;
using System.Threading;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DefuseIT_Game.Sockets
{
    class SocketConnection
    {
        /// <summary>
        /// XInput.Gamepad
        /// </summary>
        Gamepad Controller = new Gamepad();

        /// <summary>
        /// TCP Client
        /// </summary>
        internal UdpClient SocketClient = new UdpClient();
        internal UdpClient ListenClient = new UdpClient();

        /// <summary>
        /// ListenToController
        /// </summary>
        BackgroundWorker w4 = new BackgroundWorker();
        
        /// <summary>
        /// Socket Stream
        /// </summary>
        BackgroundWorker w3 = new BackgroundWorker();


        string GlobalColor;

        /// <summary>
        /// Initialize SocketConnection
        /// </summary>
        /// <param name="IPAdress"></param>
        /// <param name="Port"></param>
        internal void Initialize()
        {
            Controller.Initialize();
            StartWorker3();
        }

        /// <summary>
        /// Start BackgroundWorker3 (SocketConnection Receiving/Sending)
        /// </summary>
        private void StartWorker3()
        {
            w3.DoWork += StartStream;
            w3.WorkerSupportsCancellation = true;
            w3.RunWorkerAsync();
        }

        /// <summary>
        /// Start BackgroundWorker4 (Controller)
        /// </summary>
        private void StartWorker4()
        {
            w4.DoWork += ListenToController;
            w4.WorkerSupportsCancellation = true;
            w4.RunWorkerAsync();
        }

        /// <summary>
        /// BackgroundWorker, Listens to Controller and Sends Info to Socket Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ListenToController(object sender, DoWorkEventArgs args)
        {
            int delay = 150;
            if (Controller.GamePad == null) return;

            while (Controller.GamePad.IsConnected)
            {
                //Checks for Cancellation
                if (w4.CancellationPending == true)
                {
                    args.Cancel = true;
                    break;
                }

                if (Controller.PressedButton != "None")
                {
                    SendMessage("Button: " + Controller.PressedButton);
                    Thread.Sleep(delay);
                }

                if (Controller.LefthumbX > 0)
                {
                    SendMessage("X = " + Controller.LefthumbX);
                    Thread.Sleep(delay);
                }

                if (Controller.LTrigger != null)
                {
                    SendMessage("B = " + Controller.LTrigger);
                    Thread.Sleep(delay);
                }

                if (Controller.RTrigger != null)
                {
                    SendMessage("F = " + Controller.RTrigger);
                    Thread.Sleep(delay);
                }
            }
        }

        /// <summary>
        /// Start Socket Stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StartStream(object sender, DoWorkEventArgs args)
        {
            StartConnection(Properties.Settings.Default.IPAdressSocket, Properties.Settings.Default.PortSocket, args);
        }

        /// <summary>
        /// Initialize TCP connectie.
        /// </summary>
        /// <param name="IPAdress"></param>
        /// <param name="port"></param>
        private void StartConnection(string IPAdress, int Port, DoWorkEventArgs args)
        {
                SocketStream(args);
        }

        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.IPAdressSocket), Properties.Settings.Default.PortSocket); // endpoint where server is listening (testing localy)
        IPEndPoint ep2 = new IPEndPoint(IPAddress.Parse("192.168.2.194"), 1337);

        /// <summary>
        /// Start Socket Stream (Receive/Send)
        /// </summary>
        private void SocketStream(DoWorkEventArgs args)
        {
            ListenClient = new UdpClient();
            SocketClient = new UdpClient();
            StartWorker4();
            ListenClient.Client.Bind(new IPEndPoint(IPAddress.Parse("192.168.2.194"), 1337));

            while (true)
            {
                //Checks for Cancellation
                if (w3.CancellationPending == true)
                {
                    args.Cancel = true;
                    break;
                }


                byte[] connection = ListenClient.Receive(ref ep2);
                if (connection != null || connection.Length != 0)
                {
                    string ReturnData = Encoding.ASCII.GetString(connection);

                    if (GameManager.Colors.Contains(ReturnData))
                    {
                        if (GameManager.LastColor != ReturnData)
                        {
                            GameManager.Color = ReturnData;
                            SendMessage("Color Received: " + ReturnData);
                        }
                        GameManager.LastColor = ReturnData;
                    }
                }
            }

            ListenClient.Close();
        }

        /// <summary>
        /// Send a Message to the Socket Server
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            byte[] toBytes = Encoding.ASCII.GetBytes(message);
            SocketClient.Send(toBytes, toBytes.Length, ep);
        }
        
        /// <summary>
        /// Disconnect from the Socket Server
        /// Cancel Worker3 and Worker4
        /// Close SocketClient
        /// Set NStream to Null
        /// </summary>
        internal void DisconnectStream()
        {
            SendMessage("[!] D3FCLIENT: Disconnected");
            w3.CancelAsync();
            if (w4.WorkerSupportsCancellation) //Omdat W4 aangemaakt wordt in W3
            w4.CancelAsync();
        }
    }
}
