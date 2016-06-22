using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsTracker
{
    interface IRepository<T>
    {
        T GetItem(int i);
        List<T> GetAll();
        void SaveItem();
        void DeleteItem();
    }
}
