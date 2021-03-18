using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Billing : DbRecord, IBilling
    {
        public string ContractID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string PaymentPurposeID { get; set; }

        Contract _Contract;
        ClsItem _PaymentPurpose;
        List<IPayment> _Payments;

        public IContract Contract 
        {
            get
            {
                if (_Contract == null) _Contract = Context.GetAll<Contract>().Find(x => x.ID == this.ContractID);
                return _Contract;
            }
            set => this._Contract = value as Contract;
        }
        public IClsItem PaymentPurpose
        {
            get
            {
                if (_PaymentPurpose == null) _PaymentPurpose = Context.GetAll<ClsItem>().Find(x => x.ID == this.PaymentPurposeID);
                return _PaymentPurpose;
            }
            set => this._PaymentPurpose = value as ClsItem;
        }
        public IEnumerable<IPayment> Payments
        {
            get
            {
                if (_Payments == null)
                {
                    var paymentsToBillings = Context.GetAll<PaymentsToBillings>().FindAll(x => x.BillingID == this.ID);
                    _Payments = new List<IPayment>();
                    foreach (var item in paymentsToBillings)
                    {
                        this._Payments.Add(item.Payment);
                    }
                }
                return _Payments;
            }
            set => this._Payments = value as List<IPayment>;
        }
    }
}
