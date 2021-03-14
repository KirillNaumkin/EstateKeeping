using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Reading : DbRecord, IReading
    {
        public string GaugeID { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public float LastRate { get; set; }
    }
}
