using System;
using System.Net.Sockets;
using System.Text;
using System.ComponentModel;
using DefuseIT_Game.XInput;
using System.Threading;

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
        internal TcpClient SocketClient = new TcpClient();

        /// <summary>
        /// ListenToController
        /// </summary>
        BackgroundWorker w4 = new BackgroundWorker();
        
        /// <summary>
        /// Socket Stream
        /// </summary>
        BackgroundWorker w3 = new BackgroundWorker();

        /// <summary>
        /// NetworkStream
        /// </summary>
        NetworkStream NStream;

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
            int delay = 100;
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
            StartConnection("127.0.0.1", 5555, args);
        }

        /// <summary>
        /// Initialize TCP connectie.
        /// </summary>
        /// <param name="IPAdress"></param>
        /// <param name="port"></param>
        private void StartConnection(string IPAdress, int Port, DoWorkEventArgs args)
        {
            try
            {
                SocketClient.Connect(IPAdress, Port);
                SocketStream(args);
            }
            catch (Exception)
            {

                return;
            }
        }

        /// <summary>
        /// Start Socket Stream (Receive/Send)
        /// </summary>
        private void SocketStream(DoWorkEventArgs args)
        {
            StartWorker4();

            while (SocketClient.Connected)
            {

                //Checks for Cancellation
                if (w3.CancellationPending == true)
                {
                    args.Cancel = true;
                    break;
                }

                bool FirstConnection = true;
                byte[] Receiving = new byte[10025];
           
                NStream = SocketClient.GetStream();
                int Count = NStream.Read(Receiving, 0, Receiving.Length);
                string ReturnData = Encoding.ASCII.GetString(Receiving, 0, Count);

                if (FirstConnection)
                {
                    SendMessage("[!] D3FCLIENT: Connected");
                    FirstConnection = false;
                }
            }
        }

        /// <summary>
        /// Send a Message to the Socket Server
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            if (NStream != null && SocketClient.Connected)
            {
                byte[] Sending = Encoding.ASCII.GetBytes(message);
                NStream.Write(Sending, 0, Sending.Length);
            }
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
            SocketClient.Close();            
            NStream = null;
        }
    }
}
