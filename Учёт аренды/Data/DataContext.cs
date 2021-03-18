using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Учёт_аренды.Data.Json;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data
{
    internal class DataContext
    {
        /// <summary>Возвращает все записи классификатора.</summary>
        /// <returns>Записи классификатора.</returns>
        public static IEnumerable<IClsItem> GetCls()
        {
            return Context.GetAll<ClsItem>();
        }
        
        /// <summary>Возвращает иерархию объектов административно-территориального деления.</summary>
        /// <returns>Дерево элементов.</returns>
        public static IEnumerable<ILocation> GetLocations()
        {
            var locations = Json.Context.GetAll<Location>();
            return locations;
        }

        /// <summary>Возвращает перечень всех зданий.</summary>
        /// <returns>Перечень зданий.</returns>
        public static IEnumerable<IBuilding> GetBuildings()
        {
            return Context.GetAll<Building>();
        }

        /// <summary>Возвращает выборку помещений, расположенных в указанном здании.</summary>
        /// <param name="building">Здание, помещения которого требуется получить.</param>
        /// <returns>Перечень помещений.</returns>
        public static IEnumerable<IRoom> GetRooms(IBuilding building)
        {
            throw new NotImplementedException();
        }

        // обновление сущностей

        // удаление сущностей
    }
}
