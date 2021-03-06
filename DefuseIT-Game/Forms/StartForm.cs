﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DefuseIT_Game.XInput;
using DefuseIT_Game.GameEvents;
using DefuseIT_Game.SQL;
using System.ComponentModel;
using dmxcontrol;
using Gecko;
using System.Collections.Generic;

namespace DefuseIT_Game
{
    public partial class StartScherm : Form
    {
        /// <summary>
        /// XInput Device
        /// </summary>
        Gamepad Controller = new Gamepad();

        /// <summary>
        /// BackgroundWorker (Listen to Controller)
        /// </summary>
        BackgroundWorker w1 = new BackgroundWorker();

        /// <summary>
        /// GameManager
        /// </summary>
        GameManager gm = new GameManager();

        /// <summary>
        /// SQL
        /// </summary>
        SQLConnection connection = new SQLConnection();
        
        

        /// <summary>
        /// Initialize alle onderdelen/methods.
        /// </summary>
        public StartScherm()
        {
            InitializeComponent();
            UiEvents();
            Controller.Initialize();
            GetControllerStatus();
            StartWorker();
            lightcontrol();
            SetScoreList();
            GameManager.Color = "None";
            GameManager.KeepCounting = true;
            GameManager.PreviousColors.Clear();
            gm.Initialize(true, true);

            AudioManager.PlayAudio(true, Properties.Resources.BG1);
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
        /// Set Highscore List
        /// </summary>
        private void SetScoreList()
        {
            ScoreListBox.DataSource = connection.Select();
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
                dmxeffects.idle(5, "on");
            }

        }

        /// <summary>
        /// Start de backgroundworker (ListenToController).
        /// </summary>
        private void StartWorker()
        {
            w1.DoWork += ListenToController;
            w1.WorkerSupportsCancellation = true;
            w1.RunWorkerAsync();
        }

        /// <summary>
        /// BackgroundWorker W1 (ListenToController) zorgt ervoor dat de applicatie naar de controller output luisterd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenToController(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (Controller.GamePad == null) return;

            while (Controller.GamePad.IsConnected)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                if (Controller.PressedButton ==  "A")
                {
                    StartButton_Click(StartButton, null);
                    break;
                }
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

            ScoreListBox.BorderStyle = BorderStyle.None;
            ScoreListBox.BackColor = Gray;
            ScoreListBox.ForeColor = Yellow;

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

        /// <summary>
        /// Invoke New Form, dit is nodig omdat deze method gecalled wordt vanuit de Gamepad thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, MouseEventArgs e)
        {

            GameManager.Score = 1000;
            GameManager.Time = 0;
            GameManager.Fouten = 0;
            Trivia.Bombs[0] = false; Trivia.Bombs[1] = false; Trivia.Bombs[2] = false;

            MethodInvoker startForm = delegate
            {
                w1.CancelAsync();                       //Kill Gamepad Listener Backgroundworker
                Controller.DisconnectGamepad();         //Kill Gamepad Backgroundworker
                ControlScherm obj = new ControlScherm();
                Hide();
                obj.Closed += (s, args) => Close();
                obj.Show();
            };
            Invoke(startForm);
        }

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
