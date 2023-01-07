using Common_Class_Library.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader_Component.Interfaces
{
    public interface IReader
    {
        List<ModelData> GetPodaciFromHistorical(string criteriaName, string criteria, bool allData = false);
    }
}
