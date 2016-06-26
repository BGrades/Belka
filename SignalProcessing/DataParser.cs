using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SignalProcessing
{
    public class DataParser
    {
        public DataSeries Parse(string jsonData)
        {
            DataSeries data = JsonConvert.DeserializeObject<DataSeries>(jsonData);

            return data;
        }
    }
}
