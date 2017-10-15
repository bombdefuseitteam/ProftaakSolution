using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefuseIT_Game.XInput
{
    class Gamepad
    {
        internal Controller _gamepad;
        internal bool IsConnected = false;

        internal void Initialize()
        {
            GetGamepad();

        }

        /// <summary>
        /// Check for XInput devices and assign the Gamepad
        /// </summary>
        void GetGamepad()
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
    }
}
