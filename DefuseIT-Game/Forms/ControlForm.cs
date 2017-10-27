using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;
using DefuseIT_Game.Sockets;
using DefuseIT_Game.GameEvents;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using dmxcontrol;
using Gecko;
using System.Linq;

namespace DefuseIT_Game
{
    public partial class ControlScherm : Form
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
        /// ScoreManager
        /// </summary>
        GameManager GameEvent = new GameManager();

        /// <summary>
        /// W7 Refresh Score
        /// </summary>
        BackgroundWorker w6 = new BackgroundWorker();

        /// <summary>
        /// AntiDouble
        /// </summary>
        bool AntiDouble;

        /// <summary>
        /// 
        /// </summary>
        bool DisplayEndscreen = false;

        BackgroundWorker w8 = new BackgroundWorker();

        /// <summary>
        /// Initialize alle onderdelen/methods.
        /// </summary>
        public ControlScherm()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized; < Uncomment for P1 Event
            Xpcom.Initialize("Firefox");
            Initialize();

        }

        /// <summary>
        /// call all required Methods
        /// </summary>
        private void Initialize()
        {
            AntiDouble = false;
            Controller.Initialize();
            GetControllerStatus();
            lightcontrol();
            Socket.Initialize();
            UiEvents();
            GetSocketStatus();
            GameEvent.Initialize(false, false);
            try
            {
                WebBrowser.Navigate(Properties.Settings.Default.WebcamUrl);
            }
            catch (Exception)
            {

                
            }

            var cv = Xpcom.QueryInterface<nsIDocShell>(WebBrowser.WebBrowserFocus).GetContentViewerAttribute(); cv.SetFullZoomAttribute((float)1.6);
            StartWorker();
            
        }

        internal effects dmxeffects = new effects();
        internal color dmxcolor = new color();
        internal dmxcon dmxcon = new dmxcon();
        private void lightcontrol()
        {
            if (dmxcon.dmx.IsOpen)
            {
                dmxeffects.idle(4, "off");
                dmxcolor.allwhite(4, 255);
            }

        }

        private void GetColor(object sender, DoWorkEventArgs e)
        {

            while (AntiDouble == false)
            {
                if (GameManager.Color != GameManager.LastColor)
                {
                    if (GameManager.Color == "Blue")
                        Trivia.Bombs[0] = true;
                    if (GameManager.Color == "Green")
                        Trivia.Bombs[1] = true;
                    if (GameManager.Color == "Yellow")
                        Trivia.Bombs[2] = true;

                    if (GameManager.Color == "Red" && Trivia.Bombs[0] == true && Trivia.Bombs[1] == true && Trivia.Bombs[2] == true)
                    {
                        DisplayEndscreen = true;
                    }
                    if (w8.CancellationPending == true) //Check for Cancellation Request
                    {
                        e.Cancel = true;
                        break;
                    }
                    break;
                }
            }


            if (DisplayEndscreen == true)
            {
                GameManager.KeepCounting = false;
                w6.CancelAsync();
                MessageBox.Show("Hoeraah! Je hebt het spel uitgespeeld, goed bezig joh. Je score was: " + GameManager.Score + ", aantal fouten: " + GameManager.Fouten +  " en je tijd was: " + GameManager.Time + " seconden", "DefuseIT-Game");
                return;
            }








            if (AntiDouble == true) return;

            Controller.DisconnectGamepad();
            Socket.DisconnectStream();

            MethodInvoker startForm = delegate
            {
                Hide();
                w8.CancelAsync();
                KeuzeScherm obj = new KeuzeScherm();
                Hide();
                obj.Closed += (s, args) => Close();
                obj.Show();
            };
            Invoke(startForm);
            return;
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
        /// UI Color Hexcodes
        /// </summary>
        Color Yellow = ColorTranslator.FromHtml("#e7af03");
        Color Gray = ColorTranslator.FromHtml("#2b2b2b");
        Color LightGray = ColorTranslator.FromHtml("#969696");
        Color DarkGray = ColorTranslator.FromHtml("#222222");
        Color Red = ColorTranslator.FromHtml("#de0100");

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

        private void StartWorker()
        {
            w6.DoWork += CheckScore;
            w6.WorkerSupportsCancellation = true;
            w6.RunWorkerAsync();

            w8.DoWork += GetColor;
            w8.WorkerSupportsCancellation = true;
            w8.RunWorkerAsync();
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
        /// Haal de huidige score op
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CheckScore(object sender, DoWorkEventArgs args)
        {
            while (GameManager.Score > 0)
            {
                if (w6.CancellationPending == true) //Check for Cancellation Request
                {
                    args.Cancel = true;
                    break;
                }

                Thread.Sleep(1000);
                RefreshScore();


            }
        }
        /// <summary>
        /// Refresh het ScoreLabel
        /// </summary>
        private void RefreshScore()
        {
            MethodInvoker UI = delegate
            {
                ScoreLabel.Text = "Score: " + GameManager.Score;
            };
            Invoke(UI);
        }

        /// <summary>
        /// Luistert naar alle UI events.
        /// </summary>
        private void UiEvents()
        {
            ScoreLabel.Text = "Score: " + GameManager.Score;
            //Remove Borders from Buttons.
            CloseApplication.FlatAppearance.BorderSize = 0;
            CloseApplication.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Maximize.FlatAppearance.BorderSize = 0;
            Maximize.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Minimize.FlatAppearance.BorderSize = 0;
            Minimize.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);
            Reload.FlatAppearance.BorderSize = 0;
            Reload.FlatAppearance.BorderColor = Color.FromArgb(0, Color.Red);

            //ScoreLabel Color
            ScoreLabel.ForeColor = Yellow;
            ScoreLabel.BackColor = DarkGray;

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

            //Refresh
            Reload.MouseEnter += Refresh_MouseEnter;
            Reload.MouseLeave += Refresh_MouseLeave;
            Reload.MouseClick += Refresh_Click;
        }


        /// <summary>
        /// Restart het spel, sluit huidige form en start het StartScherm op.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartGame_Click(object sender, EventArgs e)
        {
            AntiDouble = true;
            Controller.DisconnectGamepad();         //Disconnect Gamepad Thread
            Socket.DisconnectStream();                  //Disconnect van de Socket Stream
            StartScherm obj = new StartScherm();
            Hide();
            obj.Closed += (s, args) => Close();
            obj.Show();
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
            Socket.DisconnectStream();
            dmxcon.allchannelsoff();
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

        //Refresh Button Control Scherm Only
        private void Refresh_Click(object sender, MouseEventArgs e)
        {
            AntiDouble = true;
            Controller.DisconnectGamepad();         //Disconnect Gamepad Thread
            Socket.DisconnectStream();              //Disconnect van Socket Stream
            ControlScherm obj = new ControlScherm();
            Hide();
            obj.Closed += (s, args) => Close();
            obj.Show();
        }

        private void Refresh_MouseLeave(object sender, EventArgs e)
        {
            Reload.ForeColor = Color.Black;
        }

        private void Refresh_MouseEnter(object sender, EventArgs e)
        {
            Reload.ForeColor = Color.Yellow;
        }

    }
}
