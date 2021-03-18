using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class PaymentsToBillings : DbRecord
    {
        public string BillingID { get; set; }
        public string PaymentID { get; set; }

        IBilling _Billing;
        IPayment _Payment;

        public IBilling Billing
        {
            get
            {
                if (this._Billing == null) this._Billing = Context.GetAll<Billing>().Find(x => x.ID == this.BillingID);
                return this._Billing;
            }
            set => this._Billing = value;
        }
        public IPayment Payment
        {
            get
            {
                if (this._Payment == null) this._Payment = Context.GetAll<Payment>().Find(x => x.ID == this.PaymentID);
                return this._Payment;
            }
            set => this._Payment = value;
        }
    }
}
