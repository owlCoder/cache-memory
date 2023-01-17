using Common_Class_Library.Implementations;
using Historical_Component.Implementations;
using Reader_Component.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;

namespace Reader_Component.Implementations
{
    public class Reader : MarshalByRefObject, IReader
    {
        public List<ModelData> GetPodaciFromHistorical(string criteriaName, string criteria, string test, bool allData = false)
        {
            // check is test mode active
            if(test.Equals("NUnit"))
            {
                return NUnitTestMode(criteriaName, criteria, allData);
            }

            try
            {
                Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;

                if (!allData)
                {
                    // Log Message
                    Console.WriteLine("[REQUEST] GET DATA BY CRITERIA");

                    // Log Message
                    Console.WriteLine("[REQUEST] GET DATA SUCCESS\n");

                    return HistroicalINode.GetSelectedDataByCriteria(criteriaName, criteria).ToList();
                }
                else
                {
                    // Log Message
                    Console.WriteLine("[REQUEST] GET ALL DATA");

                    // Log Message
                    Console.WriteLine("[REQUEST] GET ALL DATA SUCCESS\n");

                    return HistroicalINode.GetAllDataFromDataBase().ToList();
                }
            }
            catch
            {
                Console.WriteLine("[ERROR] UNABLE TO REACH SERVER");

                return new List<ModelData>();
            }
        }

        private static List<ModelData> NUnitTestMode(string criteriaName, string criteria, bool allData)
        {
            Historical hc = new Historical();
            // Log Message
            Console.WriteLine("[NUNIT REQUEST] GET DATA BY CRITERIA");

            // Log Message
            Console.WriteLine("[NUNIT REQUEST] GET DATA SUCCESS\n");

            if (!allData)
                return hc.GetSelectedDataByCriteria(criteriaName, criteria).ToList();
            else
                return hc.GetAllDataFromDataBase().ToList();
        }
    }
}
