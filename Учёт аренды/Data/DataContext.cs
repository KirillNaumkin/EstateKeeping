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
            var result = new List<IClsItem>();
            return result;
        }
        
        /// <summary>Возвращает записи классификатора, относящиеся к указанной категории.</summary>
        /// <param name="root">Код категории записей классификатора.</param>
        /// <returns>Записи выбранной категории.</returns>
        public static IEnumerable<IClsItem> GetCls(ClsRoots root)
        {
            return GetCls().Where(x => x.Root == root);
        }
        
        /// <summary>Возвращает иерархию объектов административно-территориального деления.</summary>
        /// <returns>Дерево элементов.</returns>
        public static IEnumerable<ILocation> GetLocationsAsync()
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
        public static Task<IEnumerable<IRoom>> GetRoomsAsync(IBuilding building)
        {
            throw new NotImplementedException();
        }

        // обновление сущностей

        // удаление сущностей
    }
}
