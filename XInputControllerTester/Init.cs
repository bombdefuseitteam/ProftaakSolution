/// XInputControllerTester
/// Wordt gebruikt om de connectie van de gamepad/controller te testen en om input/output te zien.
/// API: SharpDX
/// Author: Dominic Kleeven

namespace XInputControllerTester
{
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
