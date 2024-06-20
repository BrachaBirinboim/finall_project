using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface Icrud<T>
    {

        List<T> GetAll();
        T Add(T obg);
        //T Update(T obg, int id);
        //int Delete(T obg);
    }
}
