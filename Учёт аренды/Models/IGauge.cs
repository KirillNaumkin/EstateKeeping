using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface IGauge
    {
        string Number { get; set; }
        IClsItem ResourceType { get; set; }
        IEnumerable<IReading> Readings { get; set; }
        bool IsArchive { get; set; }
    }
}