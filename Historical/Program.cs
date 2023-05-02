using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;

namespace Historical
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            ServiceHost host;

            try
            {
                host = new ServiceHost(typeof(Historical));
                host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Historical servis je uspesno pokrenut!");
            Console.ReadLine();
        }
    }
}
