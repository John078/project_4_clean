using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker.PCL
{
    public interface IDatabase<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void DeleteById(int id);
        void Save(T item);
    }
}
