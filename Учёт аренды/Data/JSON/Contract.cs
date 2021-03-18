using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Contract : DbRecord, IContract
    {
        public DateTime AgreementDate { get; set; }
        public string Number { get; set; }
        public string RoomID { get; set; }
        public string RentGiverID { get; set; }
        public string RentHolderID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentalFee { get; set; }
        public string RentPurpose { get; set; }
        public string AccountID { get; set; }
        public string Comment { get; set; }
        public byte PayDay { get; set; }

        IRoom _Object;
        ISubject _RentGiver;
        ISubject _RentHolder;
        IAccount _Account;
        IEnumerable<IBilling> _Billings;

        public IRoom Object 
        { 
            get
            {
                if (this._Object == null) this._Object = Context.GetAll<Room>().Find(x => x.ID == this.RoomID);
                return this._Object;
            }
            set => this._Object = value; 
        }
        public ISubject RentGiver 
        {
            get
            {
                if (this._RentGiver == null) this._RentGiver = Context.GetAll<Subject>().Find(x => x.ID == this.RentGiverID);
                return this._RentGiver;
            }
            set => this._RentGiver = value; 
        }
        public ISubject RentHolder 
        {
            get
            {
                if (this._RentHolder == null) this._RentHolder = Context.GetAll<Subject>().Find(x => x.ID == this.RentHolderID);
                return this._RentHolder;
            }
            set => this._RentHolder = value;
        }
        public IAccount Account
        {
            get
            {
                if (this._Account == null) this._Account = Context.GetAll<Account>().Find(x => x.ID == this.AccountID);
                return this._Account;
            }
            set => this._Account = value;
        }
        public IEnumerable<IBilling> Billings
        {
            get
            {
                if (this._Billings == null) this._Billings = Context.GetAll<Billing>().FindAll(x => x.ContractID == this.ID);
                return this._Billings;
            }
            set => this._Billings = value;
        }
    }
}
