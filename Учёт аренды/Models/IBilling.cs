using System;
using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    interface IBilling
    {
        IContract Contract { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        decimal InvoiceAmount { get; set; }
        IClsItem PaymentPurpose { get; set; }
        IEnumerable<IPayment> Payments { get; set; }
    }
}
