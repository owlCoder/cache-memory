using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using Reader_Component.Implementations;

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
            Console.WriteLine("Za interaktivni rezim rada pritisnunti taster 'i' na tastaturi.");
            string answer = Console.ReadLine();

            while (true)
            {
                if (answer.Equals("i"))
                {
                    answer = "";
                    InteractiveMenu();
                }

                Console.Write(".");
                Thread.Sleep(2000); // svake druge sekunde ide provera
                Console.Write(".");
            }
        }

        private static void InteractiveMenu()
        {
            while (true)
            {
                Console.WriteLine("\n======================== Writer Component - Interative Menu ========================");
                Console.WriteLine("\t0. Izlaz iz interaktivnog rezima rada");
                Console.Write(">> ");

                string answer = Console.ReadLine();

                switch (answer)
                {
                    default: return;
                }
            }
        }
    }
}
