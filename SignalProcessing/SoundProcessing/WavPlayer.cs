using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SignalProcessing.SoundProcessing
{
    public class WavPlayer
    {
        public void Play(string filanme)
        {
            var effectChain = new EffectChain();
            effectChain.Add(new SuperPitch());
            //effectChain.Add(new Tremolo());

            using (var wfr = new WaveFileReader(filanme))
            using (var effectStream = new EffectStream(effectChain, wfr))
            using (WaveChannel32 wc = new WaveChannel32(effectStream) { PadWithZeroes = false })
            using (var audioOutput = new DirectSoundOut())
            {
                audioOutput.Init(wc);

                audioOutput.Play();

                while (audioOutput.PlaybackState != PlaybackState.Stopped)
                {
                    Thread.Sleep(20);
                }

                audioOutput.Stop();
            }
        }
    }
}
