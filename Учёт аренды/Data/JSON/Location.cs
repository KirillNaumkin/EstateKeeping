using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    public class Location : DbRecord, ILocation
    {
        public string ParentID { get; set; }
        public ILocation Parent { get; set; }
        public string Name { get; set; }
        public IEnumerable<ILocation> Children { get; set; }
    }
}
