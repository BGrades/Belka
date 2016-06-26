using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalProcessing
{
    public class DataGenerator
    {
        Random _random = new Random();

        public string GenerateRawSeries()
        {
            StringBuilder resultStringBuilder = new StringBuilder();

            resultStringBuilder.Append("[");

            for (int i = 0; i < 3; i++)
            {
                resultStringBuilder.Append(_random.NextDouble());
                resultStringBuilder.Append(", ");
            }

            resultStringBuilder.Append(_random.NextDouble());
            resultStringBuilder.Append("]");

            return resultStringBuilder.ToString();
        }

        public string GenerateJsonSeries()
        {
            DataSeries dataSeries = new DataSeries(GenerateRandomDoubleArray(), 
                GenerateRandomDoubleArray(), GenerateRandomMajorArray());

            string json = JsonConvert.SerializeObject(dataSeries);

            return json;
        }

        private double[] GenerateRandomDoubleArray()
        {
            double[] result = new double[4];

            for (int i = 0; i < 4; i++)
            {
                result[i] = _random.NextDouble();
            }

            return result;
        }

        private string[] GenerateRandomMajorArray()
        {
            string[] result = new string[4];

            for (int i = 0; i < 4; i++)
            {
                result[i] = _random.Next(2) == 0 ? "alpha" : "beta";
            }

            return result;
        }
    }
}
