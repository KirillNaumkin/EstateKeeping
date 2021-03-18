using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data.Json
{
    public static class Context
    {
        private static string _jsonDbFolderName = "DB-Json";

        private static void EnsureDbFolderExists()
        {
            Directory.CreateDirectory(_jsonDbFolderName);
        }

        private static string GetFileName<T>()
        {
            string result = _jsonDbFolderName + "/" + typeof(T).Name + ".json";
            return result;
        }

        /// <summary>Creates new instance of T.</summary>
        /// <typeparam name="T">Type of new instance</typeparam>
        /// <returns>New instance, created using default constructor.</returns>
        public static T CreateNew<T>() where T : DbRecord, new() => new T();

        /// <summary>Loads all records of the specified type from file (named after T.json).</summary>
        /// <typeparam name="T">File name and type of records.</typeparam>
        /// <returns>List of records if success. Null if not.</returns>
        public static List<T> GetAll<T>()
        {
            
            try
            {
                using FileStream stream = File.OpenRead(GetFileName<T>());
                var result = JsonSerializer.DeserializeAsync<List<T>>(stream).Result;
                return result;
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        /// <summary>Rewrites file (named after T.json) with given records.</summary>
        /// <typeparam name="T">File name and type of records.</typeparam>
        /// <returns>If operation was successful.</returns>
        public static bool SaveAll<T>(IEnumerable<T> records)
        {
            EnsureDbFolderExists();
            try
            {
                using FileStream stream = File.Create(GetFileName<T>());
                JsonSerializer.SerializeAsync(stream, records);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>Fullfills and adds a record into the file (named after T.json).</summary>
        /// <typeparam name="T">Name of file anf type of record.</typeparam>
        /// <param name="record">Record to add.</param>
        /// <returns>Fullfilled and added record if success. Null if not.</returns>
        public static T Add<T>(T record) where T : DbRecord
        {
            record.ID = Guid.NewGuid().ToString();
            record.IsArchive = false;
            record.DateUpdated = DateTime.Now;
            var records = GetAll<T>();
            records.Add(record);
            if (SaveAll(records)) return record;
            return null;
        }

        /// <summary>Updates a record in the file (named after T.json).</summary>
        /// <typeparam name="T">Name of file anf type of record.</typeparam>
        /// <param name="record">Record to update.</param>
        /// <returns>Updated record.</returns>
        public static T Update<T> (T record) where T : DbRecord
        {
            if (String.IsNullOrEmpty(record.ID))  // record is not identifiable
                return null;
            var records = GetAll<T>();
            var toReplace = records.Find(x => x.ID == record.ID);
            if (toReplace == null)  // no such record
                return null;
            record.DateUpdated = DateTime.Now;
            var toReplaceIdx = records.IndexOf(toReplace);
            records[toReplaceIdx] = record;
            SaveAll(records);
            return record;
        }

        /// <summary>Archives a record in a file (named after T.json).</summary>
        /// <typeparam name="T">Name of file anf type of record.</typeparam>
        /// <param name="record">Record to archive.</param>
        /// <returns>Archived record if success. Null if not.</returns>
        public static T Archive<T>(T record) where T : DbRecord
        {
            record.IsArchive = true;
            return Update(record);
        }

        /// <summary>Removes a record from the file (named after T.json).</summary>
        /// <typeparam name="T">Name of file anf type of record.</typeparam>
        /// <param name="record">Record to delete.</param>
        /// <returns>Deleted record.</returns>
        public static T Delete<T>(T record) where T : DbRecord
        {
            var records = GetAll<T>();
            var toDelete = records.Find(x => x.ID == record.ID);
            if (toDelete == null)  // no such record
                return record;
            records.Remove(toDelete);
            SaveAll(records);
            return record;
        }

        [Obsolete]
        public static List<Building> GenerateTestBuildings()
        {
            var buildings = new List<Building>();
            var c = 1;
            buildings.AddRange(Enumerable.Range(1, 3).Select(i => new Data.Json.Building
            {
                ID = Guid.NewGuid().ToString(),
                Address = $"Адрес {c}",
                Name = $"Здание {c}",
                Comment = $"Примечание к зданию {c++}",
                DateUpdated = DateTime.Now
            }));
            return buildings;
        }
    }
}
