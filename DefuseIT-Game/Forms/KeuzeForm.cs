using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;
using DefuseIT_Game.Sockets;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace DefuseIT_Game
{
    public partial class KeuzeScherm : Form
    {
        /// <summary>
        /// XInput Device
        /// </summary>
        Gamepad Controller = new Gamepad();

        /// <summary>
        /// Socket Connection
        /// </summary>
        SocketConnection Socket = new SocketConnection();

        /// <summary>
        /// W6 ListenToController
        /// </summary>
        BackgroundWorker w5 = new BackgroundWorker();

        /// <summary>
        /// Initialize alle onderdelen/methods.
        /// </summary>
        public KeuzeScherm()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized; < Uncomment for P1 Event
            Initialize();

        }

        /// <summary>
        /// call all required Methods
        /// </summary>
        private void Initialize()
        {
            Controller.Initialize();
            GetControllerStatus();
            UiEvents();
            GetSocketStatus();
            StartWorker();
        }

        /// <summary>
        /// Import user32.dll, dit is nodig voor het draggen van de Form.
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Zorgt ervoor dat de Form draggable is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSchermBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        /// <summary>
        /// Haalt de status van de controller op.
        /// </summary>
        private void GetControllerStatus()
        {

            if (Controller.IsConnected)
            {
                ControllerStatus.Image = Properties.Resources.Controller_icon_CONNECTED;
            }
        }

        /// <summary>
        /// Start W5
        /// </summary>
        private void StartWorker()
        {
            if (Controller.IsConnected)
            {
                w5.DoWork += GamepadSelectAnswer;
                w5.WorkerSupportsCancellation = true;
                w5.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Current Position (SelectedPosition)
        /// </summary>
        string CurrentPosition;

        /// <summary>
        /// Select Answer using Gamepad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GamepadSelectAnswer(object sender, DoWorkEventArgs args)
        {

            Thread.Sleep(1000);

            while (Controller.IsConnected)
            {
                int? X = Controller.LefthumbX;
                int? Y = Controller.LeftThumbY;

                if (w5.CancellationPending == true) //Check for Cancellation Request
                {
                    args.Cancel = true;
                    break;
                }


                switch (SelectedAnswer(X, Y))
                {
                    case "None":
                        {

                        }
                        break;
                    case "A":
                        {
                            InvokeUIChange(AntwoordABox, Properties.Resources.AntwoordenASelectedBox);
                            RevertUIChanges(false, true, true, true);
                            CurrentPosition = "TopLeft";
                        }
                        break;
                    case "B":
                        {
                            InvokeUIChange(AntwoordBBox, Properties.Resources.AntwoordenBSelectedBox);
                            RevertUIChanges(true, false, true, true);
                            CurrentPosition = "BottomLeft";
                        }
                        break;
                    case "C":
                        {
                            InvokeUIChange(AntwoordCBox, Properties.Resources.AntwoordenCSelectedBox);
                            RevertUIChanges(true, true, false, true);
                            CurrentPosition = "TopRight";

                        }
                        break;
                    case "D":
                        {
                            InvokeUIChange(AntwoordDBox, Properties.Resources.AntwoordenDSelectedBox);
                            RevertUIChanges(true, true, true, false);
                            CurrentPosition = "BottomRight";
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Returns Selected Answer
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private string SelectedAnswer(int? X, int? Y)
        {

            string answer = "None";
            if (X > 0 && X < 10 && Y > 11)
                answer = "A";

            if (X < 10 && Y < 10 && Y > 0 && X > 0) 
                answer = "B";

            if (X > 10 && Y > 11)
                answer = "C";

            if (X > 10 && Y < 9 && Y > 0)
                answer = "D";


            //Take in account current Position
            switch (CurrentPosition)
            {

                case "TopRight": //C
                    {
                        if (X < 9 && X > 0)
                            answer = "A";

                        if (Y < 10 && Y > 0)
                            answer = "D";
                    }
                    break;
                case "BottomRight": //D
                    {
                        if (X < 9 && X > 0)
                            answer = "B";
                        if (Y > 10)
                            answer = "C";
                    }
                    break;

                case "TopLeft": //A
                    {
                        if (X > 10)
                            answer = "C";
                        if (Y < 10 && Y > 0)
                            answer = "B";
                    }
                    break;
                case "BottomLeft": //B
                    {
                        if (X > 10)
                            answer = "D";
                        if (Y > 10)
                            answer = "A";
                    }
                    break;
            }


            return answer;
        }

        /// <summary>
        /// Verandert een picturebox UI op de UI Thread
        /// </summary>
        /// <param name="answerbox"></param>
        /// <param name="img"></param>
        private void InvokeUIChange(PictureBox answerbox, Image img)
        {
            MethodInvoker UI = delegate
            {
                answerbox.Image = img;
            };
            Invoke(UI);
        }

        /// <summary>
        /// Revert to default iamges
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        private void RevertUIChanges(bool A, bool B, bool C, bool D)
        {
            if (A) InvokeUIChange(AntwoordABox, Properties.Resources.AntwoordBoxA);
            if (B) InvokeUIChange(AntwoordBBox, Properties.Resources.AntwoordBoxB);
            if (C) InvokeUIChange(AntwoordCBox, Properties.Resources.AntwoordenCBox);
            if (D) InvokeUIChange(AntwoordDBox, Properties.Resources.AntwoordenDBox);
        }

        /// <summary>
        /// Haalt de status van de Socket Server op.
        /// Gebruikt Stopwatch i.v.m. Delay tussen het opstarten van de connectie.
        /// </summary>
        private void GetSocketStatus()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; ; i++)
            {
                if (Socket.SocketClient.Connected && sw.ElapsedMilliseconds > 100)
                {
                    SocketStatus.Image = Properties.Resources.WIFICONNECTED;
                    break;
                }
                else if (sw.ElapsedMilliseconds > 101) break;
            }

        }

        /// <summary>
        /// Luistert naar alle UI events.
        /// </summary>
        private void UiEvents()
        {
            Color Yellow = ColorTranslator.FromHtml("#e7af03");
            Color Gray = ColorTranslator.FromHtml("#2b2b2b");
            Color LightGray = ColorTranslator.FromHtml("#969696");

            //Remove Borders from Buttons.
            CloseApplication.FlatAppearance.BorderSize = 0;
            CloseApplication.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Maximize.FlatAppearance.BorderSize = 0;
            Maximize.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Minimize.FlatAppearance.BorderSize = 0;
            Minimize.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);

            //SetVraagLabel Color
            VraagLabel.ForeColor = Yellow;
            VraagLabel.BackColor = Gray;
            

            //Drag Window.
            Refresh.MouseDown += StartSchermBackground_MouseDown;

            //Close Button.
            CloseApplication.MouseEnter += CloseApplication_MouseEnter;
            CloseApplication.MouseLeave += CloseApplication_MouseLeave;
            CloseApplication.MouseClick += CloseApplication_Click;

            //Fullscreen Button.
            Maximize.MouseEnter += Maximize_MouseEnter;
            Maximize.MouseLeave += Maximize_MouseLeave;
            Maximize.MouseClick += Maximize_Click;

            //Minimize.
            Minimize.MouseEnter += Minimize_MouseEnter;
            Minimize.MouseLeave += Minimize_MouseLeave;
            Minimize.MouseClick += Minimize_Click;

        }


        /// <summary>
        /// Restart het spel, sluit huidige form en start het StartScherm op.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartGame_Click(object sender, EventArgs e)
        {
            Hide();
            Controller.DisconnectGamepad();
            StartScherm sScherm = new StartScherm();
            sScherm.Closed += (s, args) => Close();
            sScherm.Show();
        }

        //Maximize Button.
        private void Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                return;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }
        }

        private void Maximize_MouseLeave(object sender, EventArgs e)
        {
            Maximize.ForeColor = Color.Black;
        }

        private void Maximize_MouseEnter(object sender, EventArgs e)
        {
            Maximize.ForeColor = Color.Yellow;
        }

        //Minimize Button.
        private void Minimize_Click(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Minimize_MouseLeave(object sender, EventArgs e)
        {
            Minimize.ForeColor = Color.Black;
        }

        private void Minimize_MouseEnter(object sender, EventArgs e)
        {
            Minimize.ForeColor = Color.Yellow;
        }

        //Close Button.
        private void CloseApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void CloseApplication_MouseLeave(object sender, EventArgs e)
        {
            CloseApplication.ForeColor = Color.Black;
        }
        private void CloseApplication_MouseEnter(object sender, EventArgs e)
        {
            CloseApplication.ForeColor = Color.Yellow;
        }


    }
}
