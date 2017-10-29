using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;
using DefuseIT_Game.GameEvents;
using DefuseIT_Game.SQL;
using System.ComponentModel;
using dmxcontrol;
using Gecko;
using System.Threading;

namespace DefuseIT_Game
{
    public partial class EindScherm : Form
    {
        /// <summary>
        /// XInput Device
        /// </summary>
        Gamepad Controller = new Gamepad();

        /// <summary>
        /// BackgroundWorker (Listen to Controller)
        /// </summary>
        BackgroundWorker w1 = new BackgroundWorker();

        GameManager gm = new GameManager();
        SQLConnection connection = new SQLConnection();

        /// <summary>
        /// Initialize alle onderdelen/methods.
        /// </summary>
        public EindScherm()
        {
            InitializeComponent();
            UiEvents();
            EndScoreLabel.Text = "+" + GameManager.Score + "+";
            AantalFoutenLabel.Text = "aantal fouten: " + GameManager.Fouten;
            EindTijdLabel.Text = "Tijd: " + GameManager.Time + " seconden";
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
        /// Set DMX idle effect.
        /// </summary>
        internal effects dmxeffects = new effects();
        internal color dmxcolor = new color();
        internal dmxcon dmxcon = new dmxcon();

        private void lightcontrol()
        {
            if (dmxcon.dmx.IsOpen)
            {
                dmxcolor.allchannelsoff();
                dmxcolor.alldimmer(4, 255);
                dmxeffects.idle(4, "on");
            }

        }


        /// <summary>
        /// UI Color Hexcodes
        /// </summary>
        Color Green = ColorTranslator.FromHtml("#00b526");
        Color Yellow = ColorTranslator.FromHtml("#e7af03");
        Color Gray = ColorTranslator.FromHtml("#2b2b2b");
        Color LightGray = ColorTranslator.FromHtml("#969696");
        Color DarkGray = ColorTranslator.FromHtml("#222222");
        Color Red = ColorTranslator.FromHtml("#de0100");


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

            //TextColors
            NaamTextBox.ForeColor = Yellow;
            NaamTextBox.BackColor = Gray;
            NaamTextBox.BorderStyle = BorderStyle.None;

            EndScoreLabel.ForeColor = Yellow;
            EndScoreLabel.BackColor = Gray;
            EindTijdLabel.ForeColor = Yellow;
            EindTijdLabel.BackColor = Gray;
            AantalFoutenLabel.ForeColor = Yellow;
            AantalFoutenLabel.BackColor = Gray;

            //Drag Window.
            StartSchermBackground.MouseDown += StartSchermBackground_MouseDown;

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

            BevestigBox.MouseEnter += BevestigBox_MouseEnter;
            BevestigBox.MouseLeave += BevestigBox_MouseLeave;
            BevestigBox.Click += BevestigBox_Click;
           
        }

        private void BevestigBox_Click(object sender, EventArgs e)
        {
                if (NaamTextBox.Text == "")
                {
                    MessageBox.Show("Geen naam gevonden! Heeft u wel uw naam ingevuld?", "DefuseIT-Game");

                }
                else
                {
                    connection.Insert(NaamTextBox.Text, GameManager.Score);
                    Hide();
                    StartScherm obj = new StartScherm();
                    Hide();
                    obj.Closed += (s, args) => Close();
                    obj.Show();
                }

            
        }

        private void BevestigBox_MouseLeave(object sender, EventArgs e)
        {
            BevestigBox.Image = Properties.Resources.Bevestig;
        }

        private void BevestigBox_MouseEnter(object sender, EventArgs e)
        {
            BevestigBox.Image = Properties.Resources.BevestigHover;
        }

        private void RestartGame_Click(object sender, EventArgs e)
        {
            Hide();
            Controller.DisconnectGamepad();
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
            if (WindowState == FormWindowState.Maximized)
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

    }


}
