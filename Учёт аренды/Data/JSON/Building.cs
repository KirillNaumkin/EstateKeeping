using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    class Building : DbRecord, IBuilding
    {
        ILocation _Location;
        public string LocationID { get; set; }
        [JsonIgnore]
        public ILocation Location { 
            get
            {
                if (_Location == null) _Location = JsonContext.GetLocationAsync(LocationID).Result;
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
        public string Address { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<IRoom> Rooms { get; set; }
        public string Comment { get; set; }
    }
}
