using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IGauge
    {
        public string Number { get; set; }
        public IRoom Room { get; set; }
        public IClsItem ResourceType { get; set; }
        public IEnumerable<IReading> Readings { get; set; }
        public bool IsArchive { get; set; }
    }
}