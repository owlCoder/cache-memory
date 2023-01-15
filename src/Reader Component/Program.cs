using Reader_Component.Implementations;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace Reader_Component
{
    public class Program
    {
        static void Main(string[] args)
        {
            // .Net Remoting
            Reader server = new Reader();
            TcpChannel channel = new TcpChannel(8087);
            ChannelServices.RegisterChannel(channel, false);
            string uri = "Reader";
            RemotingServices.Marshal(server, uri, server.GetType());

            Console.WriteLine("READER KOMPONENTA ZAPOCINJE SA RADOM");
            Console.WriteLine("Interaktivni rezim rada nije podrzan!");

            while (true)
            {
                Thread.Sleep(2000); // svake druge sekunde ide provera
            }
        }
    }
}
