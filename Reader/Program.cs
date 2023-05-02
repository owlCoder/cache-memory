using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;

namespace Reader
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            ServiceHost host;

            try
            {
                host = new ServiceHost(typeof(Reader));
                host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Reader servis je uspesno pokrenut!");
            Console.ReadLine();
        }
    }
}
