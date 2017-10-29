using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmxcontrol
{
    class dmxcon
    {
        internal static uDMX dmx = new uDMX();
        internal void proc(int fixt, byte val, int[] channels)
        {
            for (int i = 0; i < fixt; i++)
            {

                short chan = Convert.ToInt16(channels[i]);
                dmxcon.dmx.SetSingleChannel(chan, val);
            }
        }
        internal void singleproc(int channel, byte val)
        {
            short chan = Convert.ToInt16(channel);
            dmxcon.dmx.SetSingleChannel(chan, val);
        }
        internal static void allchannelsoff()
        {
            for (int i = 0; i < 27; i++)
            {
                short chan = Convert.ToInt16(i);
                dmx.SetSingleChannel(chan, 0);
            }
        }
    }
}
