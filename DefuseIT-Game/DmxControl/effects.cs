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
        internal void correctanswer(int fixt, int fixtnum, string onoff)
        {
            int[] channelswhite = fixtures.WhiteChannels(fixt);
            int[] channelsgreen = fixtures.GreenChannels(fixt);
            int[] channelsstrobe = fixtures.StrobeChannels(fixt);
            int whitechannel = channelswhite[fixtnum];
            int greenchannel = channelsgreen[fixtnum];
            int strobechannel = channelsstrobe[fixtnum];

            if(onoff == "on")
            {
                dmxcon.singleproc(whitechannel, 0);
                dmxcon.singleproc(greenchannel, 255);
                dmxcon.singleproc(strobechannel, 240);
            }
            else
            {
                dmxcon.singleproc(whitechannel, 255);
                dmxcon.singleproc(greenchannel, 0);
                dmxcon.singleproc(strobechannel, 0);

            }

        }
        internal void wronganswer(int fixt, int fixtnum, string onoff)
        {
            int[] channelswhite = fixtures.WhiteChannels(fixt);
            int[] channelsred = fixtures.RedChannels(fixt);
            int[] channelsstrobe = fixtures.StrobeChannels(fixt);
            int whitechannel = channelswhite[fixtnum];
            int redchannel = channelsred[fixtnum];
            int strobechannel = channelsstrobe[fixtnum];

            if (onoff == "on")
            {
                dmxcon.singleproc(whitechannel, 0);
                dmxcon.singleproc(redchannel, 255);
                dmxcon.singleproc(strobechannel, 240);
            }
            else
            {
                dmxcon.singleproc(whitechannel, 255);
                dmxcon.singleproc(redchannel, 0);
                dmxcon.singleproc(strobechannel, 0);

            }

        }
        internal void bombsdone(int fixt, int fixtnum)
        {
            int[] channelswhite = fixtures.WhiteChannels(fixt);
            int[] channelsgreen = fixtures.GreenChannels(fixt);
            int whitechannel = channelswhite[fixtnum];
            int greenchannel = channelsgreen[fixtnum];
            dmxcon.singleproc(greenchannel, 255);
            dmxcon.singleproc(whitechannel, 0);
        }
    }
}
