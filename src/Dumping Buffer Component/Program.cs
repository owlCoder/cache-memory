using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text.Json;
using System.Threading;

namespace Dumping_Buffer_Component
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        static void Main(string[] args)
        {
            // .Net Remoting
            DumpingBuffer server = new DumpingBuffer();
            TcpChannel channel = new TcpChannel(8085);
            ChannelServices.RegisterChannel(channel, false);
            string uri = "DumpingBuffer";
            RemotingServices.Marshal(server, uri, server.GetType());

            Console.WriteLine("DUMPING BUFFER  ZAPOCINJE SA RADOM");
            Console.WriteLine("Interaktivni rezim rada nije podrzan!");

            while (true)
            {
                Thread.Sleep(2000); // svake druge sekunde ide provera
            }
        }
    }
}
