using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker
{
    public class BicycleBin : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string InventoryNumber { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string AtNumber { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string District { get; set; }
        public string Status { get; set; }
        public string MutationDate { get; set; }
        public string ByUser { get; set; }
    }
}
