using System;
using System.Collections.Generic;
using System.Text;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Location : DbRecord, ILocation
    {
        public string ParentID { get; set; }
        public string Name { get; set; }

        ILocation _Parent;
        IEnumerable<ILocation> _Children;

        public ILocation Parent
        {
            get
            {
                if (this._Parent == null) this._Parent = Context.GetAll<Location>().Find(x => x.ID == this.ParentID);
                return this._Parent;
            }
            set => this._Parent = value;
        }
        public IEnumerable<ILocation> Children
        {
            get
            {
                if (this._Children == null) this._Children = Context.GetAll<Location>().FindAll(x => x.ParentID == this.ID);
                return this._Children;
            }
            set => this._Children = value;
        }
    }
}
