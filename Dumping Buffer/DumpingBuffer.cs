using Common;
using Historical;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Dumping_Buffer
{
    public class DumpingBuffer : IDumpingBuffer
    {
        static List<Podatak> queue = new List<Podatak>();

        public DumpingBuffer()
        {
            // prazan konstruktor
        }

        public bool DodavanjeURedCekanja(Podatak podaci)
        {
            bool postoji = false;
            foreach (Podatak p in queue)
            {
                if (p.Equals(podaci))
                {
                    postoji = true;
                }
            }

            if (postoji)
            {
                return false;
            }
            else
            {
                queue.Add(podaci);
                return true;
            }
        }

        public void UklananjeIzRedaCekanja()
        {
            queue.RemoveAt(0);
            Console.WriteLine("Podatak je uklonjen iz reda cekanja!");
        }

        public int TrenutnoURedu()
        {
            return queue.Count;
        }
        public bool SlanjePodataka()
        {
            if (queue.Count >= 7)
            {
                Console.WriteLine("Slanje podataka ka Historical");
                for (int i = 0; i < 7; i++)
                {
                    ChannelFactory<IHistorical> kanal = new ChannelFactory<IHistorical>("Historical");
                    IHistorical proxy = kanal.CreateChannel();

                    proxy.UpisPodatkaUBazuPodataka(queue[0]);
                    UklananjeIzRedaCekanja();
                }

                Console.WriteLine("Podaci uspesno poslati na Historical");
                return true;
            }
            else
            {
                Console.WriteLine("Nema dovoljno podataka za upis u bazu podataka! Trenutno u redu cekanja {0}.", queue.Count);
                return false;
            }
        }
    }
}
