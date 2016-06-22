using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FietsTracker.PCL
{
    class GenericRepository<T> : IRepository<T> where T : IDataModel, new()
    {
        IDatabase<T> _database;

        public GenericRepository(SQLite.SQLiteConnection connection)
        {
            _database = new GenericDatabase<T>(connection);
        }

        public void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _database.GetAll();
        }

        public T GetItem(int i)
        {
            return _database.GetById(i);
        }

        public void SaveItem()
        {
            throw new NotImplementedException();
        }
    }
}
