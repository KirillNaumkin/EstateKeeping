using System;
using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface IPayment
    {
        IAccount Account { get; set; }
        DateTime Date { get; set; }
        decimal Amount { get; set; }
        string AccountString { get; set; }
        string PurposeString { get; set; }
        IEnumerable<IBilling> PaidBillings { get; set; }
        string APIID { get; set; }
    }
}