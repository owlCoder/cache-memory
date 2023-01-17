using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Implementations;

namespace Writer_Component.Interfaces
{
    public interface IWriter
    {
        void DataPassThrough(ModelData data);
        void DataPassThrough(DumpingBuffer db, ModelData data);
    }
}
