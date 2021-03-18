using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IClsItem
    {
        public IClsItem Root { get; set; }
        public string Name { get; set; }
    }
}
