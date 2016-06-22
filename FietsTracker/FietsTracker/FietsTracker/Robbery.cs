using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FietsTracker
{
    public class Robbery : IDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string IncidentNumber { get; set; }
        public string IncidentDiscoveryDate { get; set; }
        public string Category { get; set; }
        public string CategoryDescription { get; set; }
        public string Attempt { get; set; }
        public string District { get; set; }
        public string AreaOfActivity { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public string BeginKindOfDay { get; set; }
        public string BeginDate { get; set; }
        public string BeginTime { get; set; }
        public string EndKindOfDay { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string MedianYear { get; set; }
        public string MedianMonth { get; set; }
        public string MedianKindOfDay { get; set; }
        public string MedianHoursOfDay { get; set; }
        public string Keyword { get; set; }
        public string Object { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}
