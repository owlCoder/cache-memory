using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using Writer_Component.Implementations;

namespace Writer_Component
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // .Net Remoting
            Writer server = new Writer();
            TcpChannel channel = new TcpChannel(8086);
            ChannelServices.RegisterChannel(channel, false);
            string uri = "Writer";
            RemotingServices.Marshal(server, uri, server.GetType());

            Console.WriteLine("WRITER KOMPONENTA ZAPOCINJE SA RADOM");
            Console.WriteLine("Interaktivni rezim rada nije podrzan!");

            while (true)
            {
                Thread.Sleep(2000); // svake druge sekunde ide provera
            }
        }
    }
}
