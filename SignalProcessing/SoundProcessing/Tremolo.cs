using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing.SoundProcessing
{
    public class Tremolo : Effect
    {
        public Tremolo()
        {
            AddSlider(4, 0, 100, 1, "frequency (Hz)");
            AddSlider(-6, -60, 0, 1, "amount (dB)");
            AddSlider(0, 0, 1, 0.1f, "stereo separation (0..1)");
        }

        float adv, sep, amount, sc, pos;

        public override void Slider()
        {
            adv = PI * 2 * slider1 / SampleRate;
            sep = slider3 * PI;
            amount = pow(2, slider2 / 6);
            sc = 0.5f * amount; amount = 1 - amount;
        }

        public override void Sample(ref float spl0, ref float spl1)
        {
            spl0 = spl0 * ((cos(pos) + 1) * sc + amount);
            spl1 = spl1 * ((cos(pos + sep) + 1) * sc + amount);
            pos += adv;
        }

        
    }
}
