using SharpDX.XInput;
using System.Threading;
using System;

namespace XInputControllerTester
{
    /// <summary>
    /// Creates the Gamepad Object. This is made possible by using the SharpDX Api
    /// </summary>
    class XInput : Common
    {
        Controller _gamepad;

        internal void Start()
        {
            GetGamepad();
            GetGamePadState();

        }
        /// <summary>
        /// Check for XInput devices and assign the Gamepad
        /// </summary>
        void GetGamepad()
        {
            //XInput Device Array
            var devices = new[] { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };

            foreach (var gamepad in devices)
            {
                if (gamepad.IsConnected)
                {
                    _gamepad = gamepad;
                    Print("New Controller Found! Index Number = " + gamepad.UserIndex, true, true, ConsoleColor.Yellow);
                    break;
                }
            }
        }

        /// <summary>
        /// Writes Gamepad values/states to the Console
        /// </summary>
        void GetGamePadState()
        {
            while (_gamepad.IsConnected)
            {
                var state = _gamepad.GetState().Gamepad;
                var button = state.Buttons.ToString();
                var delay = 100;
                var deadZone = 5000;

                if (state.LeftThumbX > deadZone || state.LeftThumbX < -deadZone)
                {
                    Print("LeftThumb.X = " + state.LeftThumbX);
                    Thread.Sleep(delay);
                }

                if (state.LeftThumbY > deadZone || state.LeftThumbY < -deadZone)
                {
                    Print("LeftThumb.Y = " + state.LeftThumbX);
                    Thread.Sleep(delay);
                }

                if (button == "A" || button == "B" || button == "Y" || button == "X")
                {
                    Print("Button Pressed: " + button);
                    Thread.Sleep(delay);
                }

                if (state.LeftTrigger > 0)
                {
                    Print("LeftTrigger.Value = " + state.LeftTrigger);
                    Thread.Sleep(delay);
                }

                if (state.RightTrigger > 0)
                {
                    Print("RightTrigger.Value = " + state.RightTrigger);
                    Thread.Sleep(delay);
                }


            }

        }
    }
}

