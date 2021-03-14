using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Gauge : DbRecord, IGauge
    {
        public string Number { get; set; }
        public string ResourceTypeID { get; set; }
        public IClsItem ResourceType { get; set; }
        public IEnumerable<IReading> Readings { get; set; }
    }
}
