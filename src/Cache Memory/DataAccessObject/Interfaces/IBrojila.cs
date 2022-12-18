using Cache_Memory.Models;

namespace Cache_Memory.DataAccessObject.Interfaces
{
    public interface IBrojila : ICRUD<Brojilo, int>
    {
        // metoda koja pronalazi najveci id brojila u bazi podataka
        int FindMaxId();
    }
}
