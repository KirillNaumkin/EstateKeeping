using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface ILocation
    {
        string ParentID { get; set; }
        ILocation Parent { get; set; }
        string Name { get; set; }
        IEnumerable<ILocation> Children { get; set; }
        string ToString() => (Parent is null) ? Name : $"{Parent}, {Name}";
    }
}