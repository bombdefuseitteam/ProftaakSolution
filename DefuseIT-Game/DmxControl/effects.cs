using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmxcontrol
{
    class effects
    {
        dmxcon dmxcon = new dmxcon();
        fixtures fixtures = new fixtures();

        internal void idle(int fixt, string onoff)
        {
            byte intensity;
            int[] channels = fixtures.EffectChannels(fixt);
            if (onoff == "on")
            {
                intensity = 150;
            }
            else
            {
                intensity = 0;
            }
            dmxcon.proc(fixt, intensity, channels);
        }
        internal void strobe(int fixt, byte intensity)
        {
            int[] channels = fixtures.StrobeChannels(fixt);
            dmxcon.proc(fixt, intensity, channels);
        }
    }
}
