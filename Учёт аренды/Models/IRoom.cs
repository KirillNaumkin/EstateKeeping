using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface IRoom
    {
        IBuilding ParentBuilding { get; set; }
        string Name { get; set; }
        float Square { get; set; }
        IEnumerable<IGauge> Gauges { get; set; }
        ISubject Owner { get; set; }
        string Comment { get; set; }
        bool IsVacant { get; set; }
        bool IsArchive { get; set; }
        int SortOrder { get; set; }
    }
}