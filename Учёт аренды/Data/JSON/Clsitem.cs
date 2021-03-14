using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class ClsItem : DbRecord, IClsItem
    {
        public int ClsRootID { get; set; }
        public ClsRoots Root { get; set; }
        public string Name { get; set; }
    }
}
