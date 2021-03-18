using System;
using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IPayment
    {
        public IAccount Account { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string AccountString { get; set; }
        public string PurposeString { get; set; }
        public IEnumerable<IBilling> PaidBillings { get; set; }
        public string APIID { get; set; }
    }
}