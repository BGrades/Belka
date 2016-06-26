using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPListener _udpListener = new UDPListener(8888);
            Thread thread = new Thread(_udpListener.StartListener);
            thread.Start();

            UDPSender _udpSender = new UDPSender("127.0.0.1", 20381, 8888);
            _udpSender.ContiniousRandomDataSend();
        }
    }
}
