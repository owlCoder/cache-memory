using Common;
using Historical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Reader
{
    public class Reader : IReader
    {
        public List<Podatak> ProcitajPodatkeIzHistorical(string criteriaName, string criteria, bool allData = false)
        {
            ChannelFactory<IHistorical> kanal = new ChannelFactory<IHistorical>("Historical");
            IHistorical proxy = kanal.CreateChannel();

            if (!allData)
            {
                Console.WriteLine("Zahtev za citanje odredjenih podataka prihvacen!");
                return proxy.OdredjeniPodaciIzBazePodataka(criteriaName, criteria).ToList();
            }
            else
            {
                Console.WriteLine("Zahtev za citanje svih podataka prihvacen!");
                return proxy.SviPodaciIzBazePodataka().ToList();
            }
        }
    }
}
