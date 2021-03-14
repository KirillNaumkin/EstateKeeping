using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface ISubject
    {
        string Name { get; set; }
        IClsItem Type { get; set; }
        IEnumerable<IAccount> Accounts { get; set; }
    }
}