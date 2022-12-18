using System.Collections.Generic;

namespace Cache_Memory.DataAccessObject.Interfaces
{
    public interface ICRUD<T, ID>
    {
        int Count(); // ekvivalent count(*)
        int Delete(T entity);
        int DeleteAll(); // delete tabela
        int DeleteById(ID id); // brisanje konkretnog reda u tabeli
        bool ExistById(ID id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAllById(IEnumerable<ID> ids);
        T FindById(ID id);
        int Save(T entity);
        int SaveAll(IEnumerable<T> entities);
    }
}
