using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class ElectrodSeries
    {
        private List<double> _rawData;
        private List<double> _meaningfulSamples;
 
        public ElectrodSeries(List<double> rawData)
        {
            _rawData = rawData;
        }

        public List<double> GetMeaningfulSamples()
        {
            return _meaningfulSamples;
        }

        public int GetNumberOfMeaningfulSamples()
        {
            return _meaningfulSamples.Count;
        }

        public int GetElectrodAverageFrequency()
        {
            int bciSampleRate = GetOpenBciSampleRate();
            int sum = 0, count = 0;

            for (int i = 0; i < _rawData.Count / bciSampleRate; i++)
            {
                count++;
                sum += FindMeaningfulSamples(_rawData.GetRange(i*bciSampleRate, bciSampleRate)).Count;
            }

            return sum/count;
        }

        private List<double> FindMeaningfulSamples(List<double> _rawData)
        {
            return _rawData.Where(sample => sample > 0).ToList();
        }

        private int GetOpenBciSampleRate()
        {
            int sampleRate = 0;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                string stringSampleRate = appSettings["OpenBCI_SampleRate"];
                Console.WriteLine("OpenBCI_SampleRate: " + stringSampleRate);
                Int32.TryParse(stringSampleRate, out sampleRate);
    
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }

            return sampleRate;
        }
    }
}
