using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker
{
    interface IDatabase<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void DeleteById(int id);
        void Save(T item);
    }

    class GenericDatabase<T> : IDatabase<T> where T : IDataModel, new()
    {
        private SQLiteConnection databaseConnection;

        static object locker = new object();

        public GenericDatabase(SQLiteConnection c)
        {
            databaseConnection = c;
            databaseConnection.CreateTable<T>();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            lock (locker)
            {
                return (from i in databaseConnection.Table<T>() select i).ToList();
            }
        }

        public T GetById(int id)
        {
            lock(locker)
            {
                return databaseConnection.Table<T>().FirstOrDefault(x => x.ID == id);
            }
        }
    }
}
