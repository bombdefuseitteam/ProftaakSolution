using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmxcontrol
{
    class color
    {
        dmxcon dmxcon = new dmxcon();
        fixtures fixtures = new fixtures();
        internal void alldimmer(int fixt, byte val)
        {
            int[] channels = fixtures.DimmerChannels(fixt);
            dmxcon.proc(fixt, val, channels);
        }
        internal void allred(int fixt, byte val)
        {
            int[] channels = fixtures.RedChannels(fixt);
            dmxcon.proc(fixt, val, channels);
        }
        internal void allgreen(int fixt, byte val)
        {
            int[] channels = fixtures.GreenChannels(fixt);
            dmxcon.proc(fixt, val, channels);
        }
        internal void allblue(int fixt, byte val)
        {
            int[] channels = fixtures.BlueChannels(fixt);
            dmxcon.proc(fixt, val, channels);
        }
        internal void allwhite(int fixt, byte val)
        {
            int[] channels = fixtures.WhiteChannels(fixt);
            dmxcon.proc(fixt, val, channels);
        }
        internal void singlewhite(int fixt, int fixtnum, byte val)
        {
            int[] channels = fixtures.WhiteChannels(fixt);
            int whitechannel = channels[fixtnum];
            dmxcon.singleproc(whitechannel, val);
        }
        internal void allchannelsoff()
        {
            dmxcon.allchannelsoff();
        }
    }
}
