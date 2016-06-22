using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker
{
    public class BicycleBinRepository : IRepository<BicycleBin>
    {
        GenericDatabase<BicycleBin> _database;

        public BicycleBinRepository(SQLiteConnection connection)
        {
            _database = new GenericDatabase<BicycleBin>(connection);
        }

        public void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public List<BicycleBin> GetAll()
        {
            return _database.GetAll();
        }

        public BicycleBin GetItem(int i)
        {
            return _database.GetById(i);
        }

        public void SaveItem()
        {
            throw new NotImplementedException();
        }
    }
}
