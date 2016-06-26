using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing.SoundProcessing
{
    public abstract class Effect
    {
        private List<Slider> sliders;
        public float SampleRate { get; set; }
        public float Tempo { get; set; }
        public bool Enabled { get; set; }

        public Effect()
        {
            sliders = new List<Slider>();
            Enabled = true;
            Tempo = 120;
            SampleRate = 44100;
        }

        public IList<Slider> Sliders { get { return sliders; } }

        public Slider AddSlider(float defaultValue, float minimum,
                float maximum, float increment, string description)
        {
            Slider slider = new Slider(defaultValue, minimum,
                maximum, increment, description);
            sliders.Add(slider);
            return slider;
        }

        /// <summary>
        /// Should be called on effect load, 
        /// sample rate changes, and start of playback
        /// </summary>
        public virtual void Init()
        { }

        /// <summary>
        /// will be called when a slider value has been changed
        /// </summary>
        public abstract void Slider();

        /// <summary>
        /// called before each block is processed
        /// </summary>
        public virtual void Block()
        { }

        /// <summary>
        /// called for each sample
        /// </summary>
        public abstract void Sample(ref float spl0, ref float spl1);
    }
}
