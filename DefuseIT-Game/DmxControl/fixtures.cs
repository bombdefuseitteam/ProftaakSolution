using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmxcontrol
{
    class fixtures
    {
        int channelsperlight = 7;
        internal int[] DimmerChannels(int lightfixt)
        {
            int[] dimmerchannels = Channels(lightfixt, 0);
            return dimmerchannels;
        }

        internal int[] RedChannels(int lightfixt)
        {
            int[] redchannels = Channels(lightfixt, 1);
            return redchannels;
        }
        internal int[] GreenChannels(int lightfixt)
        {
            int[] greenchannels = Channels(lightfixt, 2);
            return greenchannels;
        }
        internal int[] BlueChannels(int lightfixt)
        {
            int[] bluechannels = Channels(lightfixt, 3);
            return bluechannels;
        }
        internal int[] WhiteChannels(int lightfixt)
        {
            int[] whitechannels = Channels(lightfixt, 4);
            return whitechannels;
        }
        internal int[] EffectChannels(int lightfixt)
        {
            int[] effectchannels = Channels(lightfixt, 5);
            return effectchannels;
        }
        internal int[] StrobeChannels(int lightfixt)
        {
            int[] strobechannels = Channels(lightfixt, 6);
            return strobechannels;
        }
        int[] Channels(int lightfixt, int add)
        {
            int[] channelnumbers = new int[lightfixt];
            for (int i = 0; i < lightfixt; i++)
            {
                int channels = i * channelsperlight + add;
                channelnumbers[i] = channels;
            }
            return channelnumbers;
        }
    }
}
