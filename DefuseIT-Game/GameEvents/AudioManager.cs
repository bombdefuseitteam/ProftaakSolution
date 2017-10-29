using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DefuseIT_Game.GameEvents
{
    class AudioManager
    {

        internal static SoundPlayer sp;
        internal static BackgroundWorker wsp;


        internal static void PlayAudio(bool loop, Stream audio)
        {
            wsp = new BackgroundWorker();
            wsp.DoWork += (obj, e) => AudioPlayer(loop, audio);
            wsp.RunWorkerAsync();

        }
        internal static void AudioPlayer(bool loop, Stream audio)
        {

            sp = new SoundPlayer(audio);
            if (loop)
            {
                sp.PlayLooping();
            }
            else sp.Play();
        }
    }
}
