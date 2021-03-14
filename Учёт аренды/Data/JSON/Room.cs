using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Room : DbRecord, IRoom
    {
        public string ParentBuildingID { get; set; }
        public IBuilding ParentBuilding { get; set; }
        public string Name { get; set; }
        public float Square { get; set; }
        public IEnumerable<IGauge> Gauges { get; set; }
        public string OwnerID { get; set; }
        public ISubject Owner { get; set; }
        public string Comment { get; set; }
        public bool IsVacant { get; set; }
        public int SortOrder { get; set; }
    }
}
