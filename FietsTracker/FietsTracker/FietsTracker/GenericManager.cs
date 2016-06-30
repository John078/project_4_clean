using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker.PCL
{
    public class GenericManager<T> : IManager<T> where T : IDataModel, new()
    {
        private GenericRepository<T> _repository;

        public GenericManager(SQLiteConnection connection)
        {
            _repository = new GenericRepository<T>(connection);
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetItem(id);
        }
    }
}
