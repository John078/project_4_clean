using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker.PCL
{
    public class RobberyManager : IManager<Robbery>
    {
        private RobberyRepository _repository;

        public RobberyManager(SQLiteConnection connection)
        {
            _repository = new RobberyRepository(connection);
        }

        public List<Robbery> GetAll()
        {
            return _repository.GetAll();
        }

        public Robbery GetById(int id)
        {
            return _repository.GetItem(id);
        }
    }
}
