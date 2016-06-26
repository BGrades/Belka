using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;
using SignalProcessing.SoundProcessing;

namespace SignalProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPListener _udpListener = new UDPListener(8888);
            Thread thread = new Thread(_udpListener.StartListener);
            thread.Start();

            //var sineWaveProvider = new SineWaveProvider32();
            //sineWaveProvider.SetWaveFormat(16000, 1); // 16kHz mono
            //sineWaveProvider.Frequency = 2000;
            //sineWaveProvider.Amplitude = 0.25f;
            //var waveOut = new WaveOut();
            //waveOut.Init(sineWaveProvider);
            //waveOut.Play();

            WavPlayer wav = new WavPlayer();
            wav.Play("../../resources/pampampam.wav");
            
            UDPSender _udpSender = new UDPSender("127.0.0.1", 20381, 8888);
            _udpSender.ContiniousRandomDataSend();
        }
    }
}
