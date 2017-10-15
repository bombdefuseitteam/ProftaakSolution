using SharpDX.XInput;
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
        /// Check for XInput devices and assign the Gamepad
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
        /// Start Gamepad Listening
        /// </summary>
        private void StartWorker()
        {
            w2.DoWork += GetState;
            w2.WorkerSupportsCancellation = true;
            w2.RunWorkerAsync();
        }

        /// <summary>
        /// Get Gamepad State
        /// Thread.Sleep to prevent socket overflow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetState(object sender, DoWorkEventArgs e)
        {
            if (GamePad == null) return;

            while (GamePad.IsConnected)
            {
                var state = GamePad.GetState().Gamepad;
                var button = state.Buttons.ToString();
                int delay = 100;
                int deadzone = 5000;

                if (w2.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                if (button == "A" || button == "B" || button == "Y" || button == "X")
                {
                    PressedButton = button;
                    Thread.Sleep(delay);
                    PressedButton = "None";
                }

                if (state.LeftThumbX > deadzone || state.LeftThumbX < -deadzone)
                {
                    LefthumbX = NormalizeValue(state.LeftThumbX);
                    Thread.Sleep(delay);
                    LefthumbX = null;
                }
                else
                {
                    LefthumbX = 0;
                }

                if (state.LeftTrigger > 0 && LefthumbX < 1)
                {
                    LTrigger = state.LeftTrigger;
                    Thread.Sleep(delay);
                    LTrigger = null;
                }

                if (state.RightTrigger > 0 && LefthumbX < 1)
                {
                    RTrigger = state.RightTrigger;
                    Thread.Sleep(delay);
                    RTrigger = null;
                }
            }
        }

        /// <summary>
        /// Normalize LThumbX Value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int NormalizeValue(int input)
        {
            if (input > 0)
            {
                input /= 3000;
                input += 10;
            }

            if (input < 0)
            {
                input /= 3000;
                input += 11;
            }
            return input;
        }

        /// <summary>
        /// Disconnect Gamepad Thread;
        /// </summary>
        internal void DisconnectGamepad()
        {
            w2.CancelAsync();
            IsConnected = false;
        }
    }
}
