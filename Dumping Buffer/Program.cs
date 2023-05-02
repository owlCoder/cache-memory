using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.Threading;

namespace Dumping_Buffer
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            ServiceHost host;

            try
            {
                host = new ServiceHost(typeof(DumpingBuffer));
                host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Dumping Buffer servis je uspesno pokrenut!");

            while (true)
            {
                ChannelFactory<IDumpingBuffer> kanal = new ChannelFactory<IDumpingBuffer>("DumpingBuffer");
                IDumpingBuffer proxy = kanal.CreateChannel();

                // provera da li ima dovoljno podataka za slanje na svake 2 sekunde
                proxy.SlanjePodataka();
                Thread.Sleep(2000);
            }
        }
    }
}
