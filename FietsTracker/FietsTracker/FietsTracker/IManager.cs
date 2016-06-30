using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsTracker.PCL
{
    public interface IManager<T>
    {
        T GetById(int id);
        List<T> GetAll();
    }
}
