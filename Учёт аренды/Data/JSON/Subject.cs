using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Subject : DbRecord, ISubject
    {
        public string Name { get; set; }
        public string TypeID { get; set; }
        public IClsItem Type { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }
    }
}
