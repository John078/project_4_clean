using System.Collections.Generic;
using SQLite;

namespace FietsTracker.PCL
{
    public class BicycleBinManager : IManager<BicycleBin>
    {
        private IRepository<BicycleBin> _repository;

        public BicycleBinManager(SQLiteConnection connection)
        {
            _repository = new GenericRepository<BicycleBin>(connection);
        }

        public List<BicycleBin> GetAll()
        {
            return _repository.GetAll();
        }

        public BicycleBin GetById(int id)
        {
            return _repository.GetItem(id);
        }
    }
}
