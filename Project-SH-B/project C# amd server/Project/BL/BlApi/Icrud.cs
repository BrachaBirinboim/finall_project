using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BlApi
{
    public interface Icrud<T>
    {

      
        T Add(T obg);
        //T Update(T obg, int id);
        //int Delete(int code);
    }
}
