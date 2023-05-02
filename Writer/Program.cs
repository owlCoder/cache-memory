using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;

namespace Writer
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            ServiceHost host;

            try
            {
                host = new ServiceHost(typeof(Writer));
                host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Writer servis je uspesno pokrenut!");
            Console.ReadLine();
        }
    }
}
