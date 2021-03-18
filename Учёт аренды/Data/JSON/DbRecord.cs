using System;
using System.Collections.Generic;
using System.Text;

namespace Учёт_аренды.Data.Json
{
    public class DbRecord
    {
        public string ID { get; set; }
        public bool IsArchive { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
