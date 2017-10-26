﻿using System;
using System.Net.Sockets;
using System.Text;
using System.ComponentModel;
using DefuseIT_Game.XInput;
using DefuseIT_Game.GameEvents;
using System.Threading;
using System.Linq;
using dmxcontrol;
using System.Windows.Forms;

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

                byte[] Receiving = new byte[10025];
           
                NStream = SocketClient.GetStream();
                int Count = NStream.Read(Receiving, 0, Receiving.Length);
                string ReturnData = Encoding.ASCII.GetString(Receiving, 0, Count);

                if (GameManager.Colors.Contains(ReturnData))
                {
                    if (GameManager.LastColor != ReturnData)
                    {
                        GameManager.Color = ReturnData;
                        SendMessage("Color Received: " + ReturnData);
                        dmxcon dmxcon = new dmxcon();
                        color color = new color();
                        if (dmxcon.dmx.IsOpen)
                        {

                            ColorChangerDmx(ReturnData, dmxcon, color);
                        }

                    }

                    GameManager.LastColor = ReturnData;
                }
            }
        }

        /// <summary>
        /// Change DMX Color
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dmxcon"></param>
        /// <param name="color"></param>
        private void ColorChangerDmx(string data, dmxcon dmxcon, color color)
        {
            switch (data)
            {
                case "Blue":
                    {
                        color.allwhite(4, 0);
                        color.allblue(4, 255);
                    }
                    break;
                case "Green":
                    {
                        color.allwhite(4, 0);
                        color.allgreen(4, 255);
                    }
                    break;
                case "Yellow":
                    {
                        color.allwhite(4, 0);
                        color.allwhite(4, 255);
                    }
                    break;
                case "Red":
                    {
                        color.allwhite(4, 0);
                        color.allred(4, 255);
                    }
                    break;

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
