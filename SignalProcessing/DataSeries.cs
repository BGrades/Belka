using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class DataSeries
    {
        private double[] _alpha = new double[4];
        private double[] _beta = new double[4];
        private string[] _major = new string[4];

        public DataSeries()
        {
        }
        public DataSeries(double[] alpha, double[] beta, string[] major)
        {
            _alpha = alpha;
            _beta = beta;
            _major = major;
        }

        public double[] Alpha { get { return _alpha; } set { _alpha = value; } }
        public double[] Beta { get { return _beta; } set { _beta = value; } }
        public string[] Major { get { return _major; } set { _major = value; } }

    }
}
