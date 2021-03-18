using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IRoom
    {
        public IBuilding ParentBuilding { get; set; }
        public string Name { get; set; }
        public float Square { get; set; }
        public IEnumerable<IGauge> Gauges { get; set; }
        public ISubject Owner { get; set; }
        public string Comment { get; set; }
        public bool IsVacant { get; set; }
        public bool IsArchive { get; set; }
        public int SortOrder { get; set; }
    }
}