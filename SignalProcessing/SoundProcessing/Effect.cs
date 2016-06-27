using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing.SoundProcessing
{
    /// <summary>
    /// Base class for all effects
    /// </summary>
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

        protected float slider1 { get { return sliders[0].Value; } }
        protected float slider2 { get { return sliders[1].Value; } }
        protected float slider3 { get { return sliders[2].Value; } }
        protected float slider4 { get { return sliders[3].Value; } }
        protected float slider5 { get { return sliders[4].Value; } }
        protected float slider6 { get { return sliders[5].Value; } }
        protected float slider7 { get { return sliders[6].Value; } }
        protected float slider8 { get { return sliders[7].Value; } }
        protected float min(float a, float b) { return Math.Min(a, b); }
        protected float max(float a, float b) { return Math.Max(a, b); }
        protected float abs(float a) { return Math.Abs(a); }
        protected float exp(float a) { return (float)Math.Exp(a); }
        protected float sqrt(float a) { return (float)Math.Sqrt(a); }
        protected float sin(float a) { return (float)Math.Sin(a); }
        protected float tan(float a) { return (float)Math.Tan(a); }
        protected float cos(float a) { return (float)Math.Cos(a); }
        protected float pow(float a, float b) { return (float)Math.Pow(a, b); }
        protected float sign(float a) { return Math.Sign(a); }
        protected float log(float a) { return (float)Math.Log(a); }
        protected float PI { get { return (float)Math.PI; } }

        /// <summary>
        /// Should be called on effect load, 
        /// sample rate changes, and start of playback
        /// </summary>
        public virtual void Init()
        {}

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
