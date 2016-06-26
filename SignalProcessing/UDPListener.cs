using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcessing
{
    public class UDPListener
    {
        private int _listenPort;
        private static bool done;

        public UDPListener(int listenPort)
        {
            _listenPort = listenPort;
        }

        public void StartListener()
        {
            done = false;
            string receivedData;
            UdpClient listener = new UdpClient(_listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, _listenPort);

            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    receivedData = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                        groupEP.ToString(), receivedData);

                    DataParser parser = new DataParser();

                    DataSeries data = parser.Parse(receivedData);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        public void StopListener()
        {
            done = true;
        }
    }
}
