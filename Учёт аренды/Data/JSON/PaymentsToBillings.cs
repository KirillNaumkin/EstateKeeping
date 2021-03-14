using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    public class PaymentsToBillings : DbRecord
    {
        string BillingID { get; set; }
        IBilling Billing { get; set; }
        string PaymentID { get; set; }
        IPayment Payment { get; set; }
    }
}
