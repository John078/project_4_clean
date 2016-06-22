using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker.PCL
{
    public class RobberyRepository : IRepository<Robbery>
    {
        private GenericDatabase<Robbery> _database;

        public RobberyRepository(SQLiteConnection connection)
        {
            _database = new GenericDatabase<Robbery>(connection);
        }

        public void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public List<Robbery> GetAll()
        {
            return _database.GetAll();
        }

        public Robbery GetItem(int i)
        {
            return _database.GetById(i);
        }

        public void SaveItem()
        {
            throw new NotImplementedException();
        }
    }
}
