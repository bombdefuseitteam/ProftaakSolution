using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;

namespace DefuseIT_Game
{
    public partial class ControlScherm : Form
    {
        Gamepad Controller = new Gamepad();

        /// <summary>
        /// Initialize alle onderdelen/methods.
        /// </summary>
        public ControlScherm()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Maximized; < Uncomment for P1 Event
            PlayWebcamStream();
            Controller.Initialize();
            GetControllerStatus();
            UiEvents();
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
        /// Luistert naar alle UI events.
        /// </summary>
        private void UiEvents()
        {

            //Remove Borders from Buttons.
            CloseApplication.FlatAppearance.BorderSize = 0;
            Maximize.FlatAppearance.BorderSize = 0;
            Minimize.FlatAppearance.BorderSize = 0;

            //Drag Window.
            ControlSchermBackground.MouseDown += StartSchermBackground_MouseDown;

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
        /// Speelt de webcamstream af binnen VLC.
        /// </summary>
        private void PlayWebcamStream()
        {
            WebcamStream.playlist.add("https://www.youtube.com/watch?v=th4Czv1j3F8");
            WebcamStream.playlist.play();
        }


        #region UI Elements
        /// <summary>
        /// UI Elements/Events.
        /// </summary>
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
        #endregion

        
        /// <summary>
        /// Restart het spel, sluit huidige form en start het StartScherm op.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartGame_Click(object sender, EventArgs e)
        {
            Hide();
            StartScherm sScherm = new StartScherm();
            sScherm.Closed += (s, args) => Close();
            sScherm.Show();
            WebcamStream.playlist.stop();
        }
    }
}
