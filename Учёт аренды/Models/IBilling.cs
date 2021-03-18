using System;
using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public interface IBilling
    {
        public IContract Contract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public IClsItem PaymentPurpose { get; set; }
        public IEnumerable<IPayment> Payments { get; set; }
    }
}
