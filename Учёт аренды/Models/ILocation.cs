using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface ILocation
    {
        public string ParentID { get; set; }
        public ILocation Parent { get; set; }
        public string Name { get; set; }
        public IEnumerable<ILocation> Children { get; set; }
        public string ToString() => (Parent is null) ? Name : $"{Parent}, {Name}";
    }
}