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
        /// Het geselecteerde antwoord
        /// </summary>
        string Answer = "None";

        /// <summary>
        /// Current Position (SelectedPosition)
        /// </summary>
        string CurrentPosition;

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
        /// Roep alle methods aan
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
        /// UI Color Hexcodes
        /// </summary>
        Color Yellow = ColorTranslator.FromHtml("#e7af03");
        Color Gray = ColorTranslator.FromHtml("#2b2b2b");
        Color LightGray = ColorTranslator.FromHtml("#969696");
        Color Red = ColorTranslator.FromHtml("#de0100");

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
        /// Kies en bevestig aan antwoord door middel van de controller
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
                           // if (Controller.PressedButton == "A")
                           //    ConfirmAnswer("A");

                            ChangeButtonAndLabel(AntwoordABox, Properties.Resources.AntwoordenASelectedBox, AntwoordLabelA, Yellow);
                            RevertUIChanges(false, true, true, true);
                            CurrentPosition = "TopLeft";
                        }
                        break;
                    case "B":
                        {
                           // if (Controller.PressedButton == "A")
                           //     ConfirmAnswer("B");

                            ChangeButtonAndLabel(AntwoordBBox, Properties.Resources.AntwoordenBSelectedBox, AntwoordLabelB, Yellow);
                            RevertUIChanges(true, false, true, true);
                            CurrentPosition = "BottomLeft";
                        }
                        break;
                    case "C":
                        {
                          //  if (Controller.PressedButton == "A")
                          //     ConfirmAnswer("C");

                            ChangeButtonAndLabel(AntwoordCBox, Properties.Resources.AntwoordenCSelectedBox, AntwoordLabelC, Yellow);
                            RevertUIChanges(true, true, false, true);
                            CurrentPosition = "TopRight";

                        }
                        break;
                    case "D":
                        {
                           // if (Controller.PressedButton == "A")
                           //     ConfirmAnswer("D");  
                            ChangeButtonAndLabel(AntwoordDBox, Properties.Resources.AntwoordenDSelectedBox, AntwoordLabelD, Yellow);
                            RevertUIChanges(true, true, true, false);
                            CurrentPosition = "BottomRight";
                        }
                        break;
                }
            }
        }


        /// <summary>
        /// Returns het selecteerde antwoord dat geselecteerd is door middel van de controller
        /// </summary>
        /// <param name="X"> X Position</param>
        /// <param name="Y"> Y Position</param>
        /// <returns></returns>
        private string SelectedAnswer(int? X, int? Y)
        {
            if (X > 0 && X < 10 && Y > 11)
                Answer = "A";

            if (X < 10 && Y < 10 && Y > 0 && X > 0) 
                Answer = "B";

            if (X > 10 && Y > 11)
                Answer = "C";

            if (X > 10 && Y < 9 && Y > 0)
                Answer = "D";

            switch (CurrentPosition)
            {

                case "TopRight": //C
                    {
                        if (X < 9 && X > 0)
                            Answer = "A";
                        if (Y < 10 && Y > 0)
                            Answer = "D";
                    }
                    break;
                case "BottomRight": //D
                    {
                        if (X < 9 && X > 0)
                            Answer = "B";
                        if (Y > 10)
                            Answer = "C";
                    }
                    break;

                case "TopLeft": //A
                    {
                        if (X > 10)
                            Answer = "C";
                        if (Y < 10 && Y > 0)
                            Answer = "B";
                    }
                    break;
                case "BottomLeft": //B
                    {
                        if (X > 10)
                            Answer = "D";
                        if (Y > 10)
                            Answer = "A";
                    }
                    break;
            }


            return Answer;
        }

        /// <summary>
        /// Bevestig het gekozen antwoord
        /// </summary>
        /// <param name="button"></param>
        private void ConfirmAnswer(string button)
        {
            //GetAnswerFromSQL
            var AnswerSQL = "None"; //ToDo: Haal antwoord op via SQL

            switch (button)
            {
                case "A":
                    {
                        var AnswerA = AntwoordLabelA.Text;
                        //if (AnswerA == AnswerSQL)
                        //else do stuff if false;
                    }
                    break;
                case "B":
                    {
                        var AnswerB = AntwoordLabelB.Text;
                        //if (AnswerB == AnswerSQL)
                        //else do stuff if false;
                    }
                    break;
                case "C":
                    {
                        var AnswerC = AntwoordLabelC.Text;
                        //if (AnswerC == AnswerSQL)
                        //else do stuff if false;
                    }
                    break;
                case "D":
                    {
                        var AnswerD = AntwoordLabelD.Text;
                        //if (AnswerD == AnswerSQL)
                       //else do stuff if false;
                    }
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Bepaald welk form als volgende moet komen
        /// </summary>
        private void NextForm()
        {

        }

        /// <summary>
        /// Verandert een picturebox UI op de UI Thread
        /// </summary>
        /// <param name="answerbox"></param>
        /// <param name="img"></param>
        private void ChangeButtonAndLabel(PictureBox answerbox, Image img, [Optional]Label label, [Optional]Color color)
        {
            MethodInvoker UI = delegate
            {
                answerbox.Image = img;
                label.ForeColor = color;        
            };
            Invoke(UI);
        }

        /// <summary>
        /// Revert naar de default images
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        private void RevertUIChanges(bool A, bool B, bool C, bool D)
        {
            if (A) ChangeButtonAndLabel(AntwoordABox, Properties.Resources.AntwoordBoxA, AntwoordLabelA, LightGray);
            if (B) ChangeButtonAndLabel(AntwoordBBox, Properties.Resources.AntwoordBoxB, AntwoordLabelB, LightGray);
            if (C) ChangeButtonAndLabel(AntwoordCBox, Properties.Resources.AntwoordenCBox, AntwoordLabelC, LightGray);
            if (D) ChangeButtonAndLabel(AntwoordDBox, Properties.Resources.AntwoordenDBox, AntwoordLabelD, LightGray);
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
            //Remove Borders from Buttons.
            CloseApplication.FlatAppearance.BorderSize = 0;
            CloseApplication.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Maximize.FlatAppearance.BorderSize = 0;
            Maximize.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Minimize.FlatAppearance.BorderSize = 0;
            Minimize.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);

            //SetVraagLabel Color
            VraagLabel.ForeColor = Red;
            VraagLabel.BackColor = Gray;

            //SetAntwoord Colors
            AntwoordLabelA.ForeColor = LightGray;
            AntwoordLabelA.BackColor = Gray;

            AntwoordLabelB.ForeColor = LightGray;
            AntwoordLabelB.BackColor = Gray;

            AntwoordLabelC.ForeColor = LightGray;
            AntwoordLabelC.BackColor = Gray;

            AntwoordLabelD.ForeColor = LightGray;
            AntwoordLabelD.BackColor = Gray;


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
