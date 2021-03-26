using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Gauge : DbRecord, IGauge
    {
        public string Number { get; set; }
        public string RoomID { get; set; }
        public string ResourceTypeID { get; set; }

        IRoom _Room;
        IClsItem _ResourceType;
        IEnumerable<IReading> _Readings;

        [JsonIgnore]
        public IRoom Room
        {
            get
            {
                if (this._Room == null) this._Room = Context.GetAll<Room>().Find(x => x.ID == this.RoomID);
                return this._Room;
            }
            set => this._Room = value;
        }
        
        [JsonIgnore]
        public IClsItem ResourceType
        {
            get
            {
                if (this._ResourceType == null) this._ResourceType = Context.GetAll<ClsItem>().Find(x => x.ID == this.ResourceTypeID);
                return this._ResourceType;
            }
            set => this._ResourceType = value;
        }
        
        [JsonIgnore]
        public IEnumerable<IReading> Readings
        {
            get
            {
                if (this._Readings == null) this._Readings = Context.GetAll<Reading>().FindAll(x => x.GaugeID == this.ID);
                return this._Readings;
            }
            set => this._Readings = value;
        }
    }
}
