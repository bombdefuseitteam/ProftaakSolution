using System;
using System.Runtime.InteropServices;
using XInputControllerTester;

namespace XInputControllerTester
{
    /// <summary>
    /// Project Utilities/Methods
    /// </summary>
    internal class Common
    {
        /// <summary>
        /// Print function for Console.WriteLine (Set Color + Date Display)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="printTime"></param>
        /// <param name="useColor"></param>
        /// <param name="consoleColor"></param>
        internal void Print(string message, [Optional]bool printTime, [Optional]bool useColor, [Optional]ConsoleColor consoleColor)
        {
            if (useColor)
            {
                Console.ForegroundColor = consoleColor;
            }       
            var date = DateTime.Now;
            if (printTime)
            {
                Console.WriteLine("[!] {0}: {1}", date, message);
            }
            else Console.WriteLine("[!] {0}", message);
            Console.ResetColor();
        }
    }
}
