using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface ISubject
    {
        public string Name { get; set; }
        public IClsItem Type { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }
    }
}