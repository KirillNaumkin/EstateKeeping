using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public class Building : DbRecord, IBuilding
    {
        public string LocationID { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public string LocationAndAddress { get => $"{Location}, {Address}"; }
        public string Name { get; set; }
        public string Comment { get; set; }
        
        ILocation _Location;
        IEnumerable<IRoom> _Rooms;

        [JsonIgnore]
        public ILocation Location
        { 
            get
            {
                if (_Location == null) _Location = Context.GetAll<Location>().Find(x => x.ID == this.LocationID.ToString());
                return _Location;
            }
            set => _Location = value;
        }
        
        [JsonIgnore]
        public IEnumerable<IRoom> Rooms
        {
            get
            {
                if (_Rooms == null) _Rooms = Context.GetAll<Room>().FindAll(x => x.ParentBuildingID == this.ID);
                return _Rooms;
            }
            set => _Rooms = value;
        }
    }
}
