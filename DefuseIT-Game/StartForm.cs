﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;
using System.ComponentModel;

namespace DefuseIT_Game
{
    public partial class StartScherm : Form
    {

        Gamepad _controller = new Gamepad();

        public StartScherm()
        {
            InitializeComponent();
            UiEvents();
            _controller.Initialize();
            GetControllerStatus();
            StartWorkers();
        }

        //Import, Values + Draggable Window.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Drag Window Function
        private void StartSchermBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        //Get Controller Status
        private void GetControllerStatus()
        {
            if (_controller.IsConnected)
            {
                ControllerStatus.Image = Properties.Resources.Controller_icon_CONNECTED;
            }
        }

        //Start BackgroundWorkers
        private void StartWorkers()
        {
            BackgroundWorker w1 = new BackgroundWorker();
            w1.DoWork += ListenToController;
            w1.RunWorkerAsync();
        }

        //BackgroundWorker w1 start listening to controller
        private void ListenToController(object sender, DoWorkEventArgs e)
        {
            if (_controller._gamepad == null) return;

            while (_controller._gamepad.IsConnected)
            {
                if (_controller.PressedButton ==  "A")
                {
                    StartButton_Click(StartButton, null);
                    break;
                }
            }
        }

        private void UiEvents()
        {

            //Remove Borders from Buttons.
            CloseApplication.FlatAppearance.BorderSize = 0;
            Maximize.FlatAppearance.BorderSize = 0;
            Minimize.FlatAppearance.BorderSize = 0;

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

            //StartButton.
            StartButton.MouseEnter += StartButton_MouseEnter;
            StartButton.MouseLeave += StartButton_MouseLeave;
            StartButton.MouseClick += StartButton_Click;

           
        }

        //Invoke ControlScherm
        private void StartButton_Click(object sender, MouseEventArgs e)
        {
            MethodInvoker startForm = delegate
            {
                Hide();
                ControlScherm cS = new ControlScherm();
                cS.Closed += (s, args) => Close();
                cS.Show();

            };
            Invoke(startForm);
        }

        private void StartScherm_Load(object sender, EventArgs e)
        {

        }






























      /// <summary>
      /// UI Elements Events
      /// </summary>

        //StartButton.
        private void StartButton_MouseLeave(object sender, EventArgs e)
        {
            StartButton.Image = Properties.Resources.StartButton;
        }

        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            StartButton.Image = Properties.Resources.StartButtonHover;
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
