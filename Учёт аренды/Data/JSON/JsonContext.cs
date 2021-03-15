using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.JSON
{
    internal static class JsonContext
    {
        private static string _jsonDbFolder     = "DB";
        private static string _accountsFile     = _jsonDbFolder + "/Accounts.json";

        private static string _billingsFile     = _jsonDbFolder + "/Billings.json";
        private static string _buildingsFile    = _jsonDbFolder + "/Buildings.json";
        private static string _clsFile          = _jsonDbFolder + "/Cls.json";
        private static string _contractsFile    = _jsonDbFolder + "/Contracts.json";
        private static string _gaugesFile       = _jsonDbFolder + "/Gauges.json";
        private static string _locationsFile    = _jsonDbFolder + "/Locations.json";
        private static string _paymentsFile     = _jsonDbFolder + "/Payments.json";
        private static string _paymentsToBillingsFile = _jsonDbFolder + "/PaymentsToBillings.json";
        private static string _readingsFile     = _jsonDbFolder + "/Readings.json";
        private static string _roomsFile        = _jsonDbFolder + "/Rooms.json";
        private static string _subjectsFile     = _jsonDbFolder + "/Subjects.json";

        private static IEnumerable<ClsItem> _Cls;
        private static IEnumerable<Location> _Locations;

        private static void EnsureDbFolderExists()
        {
            Directory.CreateDirectory(_jsonDbFolder);
        }

        internal static async Task<IEnumerable<IClsItem>> GetClsAsync()
        {
            using FileStream stream = File.OpenRead(_clsFile);
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<IClsItem>>(stream);
            return result;
        }

        internal static async Task SaveClsAsync()
        {
            EnsureDbFolderExists();
            using FileStream createStream = File.Create(_clsFile);
            await JsonSerializer.SerializeAsync(createStream, _Cls);
            _Locations = null;
        }

        internal static async Task<IEnumerable<Building>> GetBuildingsAsync() 
        {
            using FileStream stream = File.OpenRead(_buildingsFile);
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Building>>(stream);
            return result;
        }
        
        internal static async Task SaveBuildingsAsync(IEnumerable<Building> buildings) 
        {
            EnsureDbFolderExists();
            using FileStream createStream = File.Create(_buildingsFile);
            await JsonSerializer.SerializeAsync(createStream, buildings);
        }
        
        internal static List<Building> GenerateTestBuildings()
        {
            var buildings = new List<Building>();
            var c = 1;
            buildings.AddRange(Enumerable.Range(1, 3).Select(i => new Data.JSON.Building
            {
                ID = Guid.NewGuid().ToString(),
                Address = $"Адрес {c}",
                Name = $"Здание {c}",
                Comment = $"Примечание к зданию {c++}",
                DateUpdated = DateTime.Now
            }));
            return buildings;
        }

        internal static async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            if (_Locations == null)
            {
                using FileStream stream = File.OpenRead(_locationsFile);
                _Locations = await JsonSerializer.DeserializeAsync<IEnumerable<Location>>(stream);
            }
            return _Locations;
        }

        internal static async Task<Location> GetLocationAsync(string locationID)
        {
            var locations = await GetLocationsAsync();
            return locations?.FirstOrDefault(x => x.ID == locationID);
        }

        internal static async Task SaveLocationsAsync()
        {
            EnsureDbFolderExists();
            using FileStream createStream = File.Create(_locationsFile);
            await JsonSerializer.SerializeAsync(createStream, _Locations);
            _Locations = null;
        }
    }
}
