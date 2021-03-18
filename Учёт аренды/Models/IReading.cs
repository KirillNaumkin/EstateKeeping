using System;

namespace Учёт_аренды.Models
{
    public interface IReading
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public float LastRate { get; set; }
    }
}