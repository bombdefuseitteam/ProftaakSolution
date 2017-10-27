using SharpDX.XInput;
using System;
using System.ComponentModel;
using System.Threading;

namespace DefuseIT_Game.XInput
{
    class Gamepad
    {
        /// <summary>
        /// XInput.Gamepad
        /// </summary>
        internal Controller GamePad;

        /// <summary>
        /// BackgroundWorker GetState
        /// </summary>
        BackgroundWorker w2 = new BackgroundWorker();

        /// <summary>
        /// IsConnected Boolean
        /// </summary>
        internal bool IsConnected = false;

        /// <summary>
        /// Last Pressed Button
        /// </summary>
        internal string PressedButton = "None";

        /// <summary>
        /// LeftThumbX value
        /// </summary>
        internal int? LefthumbX;

        /// <summary>
        /// LeftThumbY value
        /// </summary>
        internal int? LeftThumbY;

        /// <summary>
        /// LeftTrigger Value
        /// </summary>
        internal int? LTrigger;

        /// <summary>
        /// RightTrigger Value
        /// </summary>
        internal int? RTrigger;


        /// <summary>
        /// Initialize
        /// </summary>
        internal void Initialize()
        {
            GetGamepad();
            StartWorker();

        }

        /// <summary>
        /// Controlleer alle aangesloten devices en bepaal welke de controller is.
        /// </summary>
        private void GetGamepad()
        {
            ///XInput Device Array
            var devices = new[] { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };

            foreach (var gamepad in devices)
            {
                if (gamepad.IsConnected && gamepad != null)
                {
                    GamePad = gamepad;
                    IsConnected = true;
                    break;
                }
                else
                {
                    IsConnected = false;
                }
            }
        }

        /// <summary>
        /// Start Worker2 hierdoor luisterd de applicatie naar de controller
        /// </summary>
        private void StartWorker()
        {
            w2.DoWork += GetState;
            w2.WorkerSupportsCancellation = true;
            w2.RunWorkerAsync();
        }

        /// <summary>
        /// Get Gamepad State
        /// Thread.Sleep is om socket overflow te voorkomen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetState(object sender, DoWorkEventArgs e)
        {
            if (GamePad == null) return;

            while (GamePad.IsConnected)
            {
                try
                {
                    var state = GamePad.GetState().Gamepad;
                    var button = state.Buttons.ToString();

                    int delay = 150;
                    int deadzone = 4000;

                    if (w2.CancellationPending == true) //Check for Cancellation Request
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (button != "None")
                    {
                        PressedButton = button;
                        Thread.Sleep(delay);
                        PressedButton = "None";
                    }

                    if (state.LeftThumbX > deadzone || state.LeftThumbX < -deadzone)
                    {
                        LefthumbX = NormalizeValue(state.LeftThumbX);
                        Thread.Sleep(delay);
                    }
                    else
                    {
                        LefthumbX = 0;
                    }

                    if (state.LeftThumbY > deadzone || state.LeftThumbY < -deadzone)
                    {
                        LeftThumbY = NormalizeValue(state.LeftThumbY);
                        Thread.Sleep(delay / 2);
                    }
                    else
                    {
                        LeftThumbY = 0;
                    }


                    if (state.LeftTrigger > 0 && LefthumbX < 1)
                    {
                        LTrigger = state.LeftTrigger * 2;
                        Thread.Sleep(delay);
                        LTrigger = null;
                    }

                    if (state.RightTrigger > 0 && LefthumbX < 1)
                    {
                        RTrigger = state.RightTrigger * 2;
                        Thread.Sleep(delay);
                        RTrigger = null;
                    }
                }
                catch (Exception)
                {

                    break;
                }


            }
        }

        /// <summary>
        /// Normalizeer de Thumbstick values (value tussen 1-20)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int NormalizeValue(int input)
        {
            if (input > 0)
            {
                input /= 3000;
                input += 10;
                input = input * (255 / 10);
            }

            if (input < 0)
            {
                input /= 3000;
                input += 11;
                input = input * (255 / 10); //11 = dan 
            }
            return input;
        }

        /// <summary>
        /// Sluit de Gamepad Thread
        /// </summary>
        internal void DisconnectGamepad()
        {
            w2.CancelAsync();
            IsConnected = false;
        }
    }
}
