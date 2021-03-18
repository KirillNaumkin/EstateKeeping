using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class ClsItem : DbRecord, IClsItem
    {
        public string ClsRootID { get; set; }
        public string Name { get; set; }

        IClsItem _Root;

        public IClsItem Root
        {
            get
            {
                if (this._Root == null) this._Root = Context.GetAll<ClsItem>().Find(x => x.ID == this.ClsRootID);
                return this._Root;
            }
            set => this._Root = value;
        }
    }
}
