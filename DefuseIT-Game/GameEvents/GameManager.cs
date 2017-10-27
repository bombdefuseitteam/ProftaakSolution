using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefuseIT_Game.GameEvents
{
    class GameManager
    {
        /// <summary>
        /// Base Score
        /// </summary>
        internal static int Score;

        /// <summary>
        /// Time
        /// </summary>
        internal static int Time;

        /// <summary>
        /// Foute antwoorden
        /// </summary>
        internal static int Fouten;

        /// <summary>
        /// Checking for Colors
        /// </summary>
        internal static string[] Colors = { "Blue", "Green", "Yellow", "Red" };

        /// <summary>
        /// Last Found Color
        /// </summary>
        internal static string LastColor = "None";

        /// <summary>
        /// Current Color
        /// </summary>
        internal static string Color = "None";

        /// <summary>
        /// Score Timer
        /// </summary>
        BackgroundWorker w7 = new BackgroundWorker();


        /// <summary>
        /// Initiliaze scoremanager
        /// </summary>
        internal void Initialize(bool setscore)
        {
            if (setscore)
            {
                Score = 1000; //Base Score
            }

            StartWorker();
        }

        /// <summary>
        /// Start Worker w7 (-5 score every second)
        /// </summary>
        private void StartWorker()
        {

            w7.DoWork += AssignScore;
            w7.WorkerSupportsCancellation = true;
            w7.RunWorkerAsync();
        }

        private void AssignScore(object sender, DoWorkEventArgs e)
        {

            while (Score > 0)
            {
                if (w7.CancellationPending == true) //Check for Cancellation Request
                {
                    e.Cancel = true;
                    break;
                }

                Time += 1;
                Score -= 2;
                Thread.Sleep(1000);
            }
        }
    }
}
