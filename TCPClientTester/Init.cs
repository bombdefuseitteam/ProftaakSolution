/// TCPClientTester
/// Wordt gebruikt om de communicatie tussen de server en de client te testen.
/// Send & Receive
/// Author: Dominic Kleeven

namespace TCPClientTester
{
    class Init
    {
        /// <summary>
        /// Initialize Socket Connection
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SocketConnection tcpClient = new SocketConnection();
            tcpClient.InitializeConnection();
        }
    }
}
