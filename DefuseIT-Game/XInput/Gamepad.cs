using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefuseIT_Game.XInput
{
    class Gamepad
    {
        internal Controller _gamepad;
        internal bool IsConnected = false;
        internal string PressedButton = "None";

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
                    _gamepad = gamepad;
                    IsConnected = true;
                    break;
                }
                else
                {
                    IsConnected = false;
                }
            }
        }


        private void StartWorker()
        {
            BackgroundWorker w2 = new BackgroundWorker();
            w2.DoWork += GetState;
            w2.RunWorkerAsync();
        }

        private void GetState(object sender, DoWorkEventArgs e)
        {
            if (_gamepad == null) return;

            while (_gamepad.IsConnected)
            {
                var state = _gamepad.GetState().Gamepad;
                var button = state.Buttons.ToString();

                if (button == "A" || button == "B" || button == "Y" || button == "X")
                {
                    PressedButton = button;
                    Thread.Sleep(500);
                }
            }
        }
    }
}
