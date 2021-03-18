using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Payment : DbRecord, IPayment
    {
        public string AccountID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string AccountString { get; set; }
        public string PurposeString { get; set; }
        public string APIID { get; set; }

        IAccount _Account;
        List<IBilling> _PaidBillings;

        public IAccount Account
        {
            get
            {
                if (this._Account == null) this._Account = Context.GetAll<Account>().Find(x => x.ID == this.AccountID);
                return this._Account;
            }
            set => this._Account = value;
        }
        public IEnumerable<IBilling> PaidBillings
        {
            get
            {
                if (_PaidBillings == null)
                {
                    var paymentsToBillings = Context.GetAll<PaymentsToBillings>().FindAll(x => x.PaymentID == this.ID);
                    _PaidBillings = new List<IBilling>();
                    foreach (var item in paymentsToBillings)
                    {
                        this._PaidBillings.Add(item.Billing);
                    }
                }
                return this._PaidBillings;
            }
            set => this._PaidBillings = (List<IBilling>)value;
        }
    }
}
