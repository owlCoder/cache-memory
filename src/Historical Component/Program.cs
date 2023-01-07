using Historical_Component.Implementations;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace Historical_Component
{
    public class Program
    {
        static void Main(string[] args)
        {
            // .Net Remoting
            Historical server = new Historical();
            TcpChannel channel = new TcpChannel(8090);
            ChannelServices.RegisterChannel(channel, false);
            string uri = "Historical";
            RemotingServices.Marshal(server, uri, server.GetType());

            Console.WriteLine("HISTORICAL KOMPONENTA ZAPOCINJE SA RADOM");
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
                Console.WriteLine("\n======================== Historical Component - Interative Menu ========================");
                Console.WriteLine("\t1. Rucni Upis podataka u bazu podataka");
                Console.WriteLine("\t2. Iscitavanje svih podataka o potrosnji");
                Console.WriteLine("\t3. Iscitavanje podataka po kriterijumu");
                Console.WriteLine("\t4. Izlaz iz interaktivnog rezima rada");
                Console.Write(">> ");

                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1": ManualInsert(); break;
                    case "2": ReadAll(); break;
                    case "3": ReadByCriteria(); break;
                    default: return;
                }
            }
        }

        private static void ReadByCriteria()
        {
            throw new NotImplementedException();
        }

        private static void ReadAll()
        {
            throw new NotImplementedException();
        }

        private static void ManualInsert()
        {
            throw new NotImplementedException();
        }
    }
}
