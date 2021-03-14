using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface IBuilding
    {
        ILocation Location { get; set; }
        string Address { get; set; }
        string LocationAndAddress { get => $"{Location}, {Address}"; }
        string Name { get; set; }
        IEnumerable<IRoom> Rooms { get; set; }
        string Comment { get; set; }
        bool IsArchive { get; set; }
    }
}
