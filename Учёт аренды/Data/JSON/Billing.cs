using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Billing : DbRecord, IBilling
    {
        public string ContractID { get; set; }
        public IContract Contract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string PaymentPurposeID { get; set; }
        public IClsItem PaymentPurpose { get; set; }
        public IEnumerable<IPayment> Payments { get; set; }
    }
}
