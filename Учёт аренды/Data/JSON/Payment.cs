using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Payment : DbRecord, IPayment
    {
        public string AccountID { get; set; }
        public IAccount Account { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string AccountString { get; set; }
        public string PurposeString { get; set; }
        public IEnumerable<IBilling> PaidBillings { get; set; }
        public string APIID { get; set; }
    }
}
