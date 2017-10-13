using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XInputControllerTester
{

    /// XInputControllerTester
    /// Author: Dominic Kleeven
    class Init
    {

        /// <summary>
        /// Initialize XinputControllerTester
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            XInput gamePad = new XInput();
            gamePad.Start();
        }
    }
}
