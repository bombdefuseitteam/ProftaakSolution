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
    class ScoreManager
    {
        /// <summary>
        /// Base Score
        /// </summary>
        internal static int Score;

        /// <summary>
        /// Checking for Colors
        /// </summary>
        internal string[] Colors = { "Blue", "Groen", "Yellow", "Red" };

        /// <summary>
        /// Last Found Color
        /// </summary>
        internal static string LastColor = "None";
        


        /// <summary>
        /// Initiliaze scoremanager
        /// </summary>
        internal void Initialize()
        {
            Score = 1000;
            StartWorker();
        }

        /// <summary>
        /// Controleert de gedecteerde kleur
        /// </summary>
        /// <param name="color"></param>
        private void CheckColor(string color)
        {
            if (Colors.Contains(color) || LastColor != color)
            {
                //StartKeuzeScherm
            }
        }

        /// <summary>
        /// Start Worker w7 (-5 score every second)
        /// </summary>
        private void StartWorker()
        {
            BackgroundWorker w7 = new BackgroundWorker();
            w7.DoWork += AssignScore;
            w7.WorkerSupportsCancellation = true;
            w7.RunWorkerAsync();
        }

        private void AssignScore(object sender, DoWorkEventArgs e)
        {
            while (Score > 0)
            {
                Score -= 5;
                Thread.Sleep(1000);
            }
        }
    }
}
