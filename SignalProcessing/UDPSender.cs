using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace SignalProcessing
{
    public class UDPSender
    {
        private UdpClient _udpClient;
        private DataGenerator _dataGenerator;

        public UDPSender(string address, int sourcePort, int destinationPort)
        {
            _udpClient = new UdpClient(sourcePort);
            _udpClient.Connect(address, destinationPort);
            _dataGenerator = new DataGenerator();
        }

        public void Send(string data)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(data);
            _udpClient.Send(sendBytes, sendBytes.Length);
        }

        public void ContiniousRandomDataSend()
        {
            Timer timer1;

            timer1 = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer.
            timer1.Elapsed += SendRandomData;

            timer1.Start();
        }

        private void SendRandomData(object source, ElapsedEventArgs e)
        {
            string dataSeries = _dataGenerator.GenerateJsonSeries();
            Send(dataSeries);
        }
    }
}
