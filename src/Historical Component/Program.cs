using Common_Class_Library.Implementations;
using Historical_Component.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace Historical_Component
{
    [ExcludeFromCodeCoverage]
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
            try
            {
                Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;

                Console.Write("Unesite naziv kriterijuma pretrage: ");
                string criteria = Console.ReadLine();

                Console.Write("Unesite vrednost kriterijuma pretrage: ");
                string value = Console.ReadLine();

                List<ModelData> lista = HistroicalINode.GetSelectedDataByCriteria(criteria, value).ToList();

                Console.WriteLine("\n{0, -7}{1, -20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", "USERID", "USERNAME", "USERADDRESS", "USERCITY", "BROJILOID", "POTROSENO", "POTROSNJAMESEC");
                if (lista != null && lista.Count > 0)
                {
                    foreach (ModelData m in lista)
                    {
                        Console.WriteLine("{0, -7}{1, -20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", m.UserID, m.Username, m.UserAddress, m.UserCity, m.BrojiloId, m.Potroseno, m.Mesec);
                    }
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("\nGreska prilikom citanja podataka!");
            }
        }

        private static void ReadAll()
        {
            try
            {
                Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;

                List<ModelData> lista = HistroicalINode.GetAllDataFromDataBase().ToList();

                Console.WriteLine("\n{0, -7}{1, -20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", "USERID", "USERNAME", "USERADDRESS", "USERCITY", "BROJILOID", "POTROSENO", "POTROSNJAMESEC");
                if (lista != null && lista.Count > 0)
                {
                    foreach (ModelData m in lista)
                    {
                        Console.WriteLine("{0, -7}{1, -20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", m.UserID, m.Username, m.UserAddress, m.UserCity, m.BrojiloId, m.Potroseno, m.Mesec);
                    }
                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("\nGreska prilikom citanja podataka!");
            }
        }

        private static void ManualInsert()
        {
            try
            {
                Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;

                Console.Write("Unesite USERID: ");
                int userId = int.Parse(Console.ReadLine());

                Console.Write("Unesite USERNAME: ");
                string username = Console.ReadLine();

                Console.Write("Unesite USERADDRESS: ");
                string userAddress = Console.ReadLine();

                Console.Write("Unesite USERCITY: ");
                string userCity = Console.ReadLine();

                Console.Write("Unesite BROJILOID: ");
                string brojiloid = Console.ReadLine();

                Console.Write("Unesite POTROSENO: ");
                decimal potroseno = decimal.Parse(Console.ReadLine());

                Console.Write("Unesite POTROSNJAMESEC: ");
                string mesec = Console.ReadLine();

                HistroicalINode.WriteModelDataToDataBase(new ModelData(userId, username, userAddress, userCity, brojiloid, potroseno, mesec));
            }
            catch
            {
                Console.WriteLine("\nGreska prilikom upisa podataka!");
            }
        }
    }
}
