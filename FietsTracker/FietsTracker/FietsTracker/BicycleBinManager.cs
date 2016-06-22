using System.Collections.Generic;
using SQLite;

namespace FietsTracker.PCL
{
    public class BicycleBinManager : IManager<BicycleBin>
    {
        private BicycleBinRepository _repository;

        public BicycleBinManager(SQLiteConnection connection)
        {
            _repository = new BicycleBinRepository(connection);
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
