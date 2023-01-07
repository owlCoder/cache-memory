using Common_Class_Library.Implementations;
using Historical_Component.Implementations;
using Reader_Component.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Reader_Component.Implementations
{
    public class Reader : MarshalByRefObject, IReader
    {
        public List<ModelData> GetPodaciFromHistorical(string criteriaName, string criteria, bool allData = false)
        {
            if(!allData) 
            {
                Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;
                return HistroicalINode.GetSelectedDataByCriteria(criteriaName, criteria).ToList();
            }
            else
            {
                Historical HistroicalINode = RemotingServices.Connect(typeof(Historical), "tcp://localhost:8090/Historical") as Historical;
                return HistroicalINode.GetAllDataFromDataBase().ToList();
            }
            
        }
    }
}
