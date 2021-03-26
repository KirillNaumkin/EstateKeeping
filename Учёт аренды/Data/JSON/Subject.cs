using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Subject : DbRecord, ISubject
    {
        public string Name { get; set; }
        public string TypeID { get; set; }

        IClsItem _Type;
        IEnumerable<IAccount> _Accounts;

        [JsonIgnore]
        public IClsItem Type
        {
            get
            {
                if (this._Type == null) this._Type = Context.GetAll<ClsItem>().Find(x => x.ID == this.TypeID);
                return this._Type;
            }
            set => this._Type = value;
        }
        
        [JsonIgnore]
        public IEnumerable<IAccount> Accounts
        {
            get
            {
                if (this._Accounts == null) this._Accounts = Context.GetAll<Account>().FindAll(x => x.SubjectID == this.ID);
                return this._Accounts;
            }
            set => this._Accounts = value;
        }
    }
}
