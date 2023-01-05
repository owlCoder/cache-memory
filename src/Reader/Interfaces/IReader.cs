using Common.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Interfaces
{
    public interface IReader
    {
        List<ModelData> GetPodaciFromHistorical(string criteriaName, string criteria);
    }
}
