using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Room : DbRecord, IRoom
    {
        public string ParentBuildingID { get; set; }
        public string Name { get; set; }
        public float Square { get; set; }
        public string OwnerID { get; set; }
        public string Comment { get; set; }
        public bool IsVacant { get; set; }
        public int SortOrder { get; set; }

        IBuilding _ParentBuilding;
        IEnumerable<IGauge> _Gauges;
        ISubject _Owner;

        [JsonIgnore]
        public IBuilding ParentBuilding
        {
            get
            {
                if (this._ParentBuilding == null) this._ParentBuilding = Context.GetAll<Building>().Find(x => x.ID == this.ParentBuildingID);
                return this._ParentBuilding;
            }
            set => this._ParentBuilding = value; 
        }
        
        [JsonIgnore]
        public IEnumerable<IGauge> Gauges
        {
            get
            {
                if (this._Gauges == null) this._Gauges = Context.GetAll<Gauge>().FindAll(x => x.RoomID == this.ID);
                return this._Gauges;
            }
            set => this._Gauges = value;
        }
        
        [JsonIgnore]
        public ISubject Owner
        {
            get
            {
                if (this._Owner == null) this._Owner = Context.GetAll<Subject>().Find(x => x.ID == this.OwnerID);
                return this._Owner;
            }
            set => this._Owner = value;
        }
    }
}
