using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IBuilding
    {
        public ILocation Location { get; set; }
        public string Address { get; set; }
        public string LocationAndAddress { get; }
        public string Name { get; set; }
        public IEnumerable<IRoom> Rooms { get; set; }
        public string Comment { get; set; }
        public bool IsArchive { get; set; }
    }
}
