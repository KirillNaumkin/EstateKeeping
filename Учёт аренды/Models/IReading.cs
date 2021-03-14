using System;

namespace Учёт_аренды.Models
{
    interface IReading
    {
        DateTime Date { get; set; }
        float Value { get; set; }
        float LastRate { get; set; }
    }
}