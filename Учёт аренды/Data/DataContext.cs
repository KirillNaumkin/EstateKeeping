using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Учёт_аренды.Models;

namespace Учёт_аренды.Data
{
    internal class DataContext
    {
        //private static IEnumerable<IBuilding> _Buildings;
        
        /// <summary>
        /// Возвращает все записи классификатора.
        /// </summary>
        /// <returns>Записи классификатора.</returns>
        public static IEnumerable<IClsItem> GetCls()
        {
            var result = new List<IClsItem>();
            return result;
        }
        
        /// <summary>
        /// Возвращает записи классификатора, относящиеся к указанной категории.
        /// </summary>
        /// <param name="root">Код категории записей классификатора.</param>
        /// <returns>Записи выбранной категории.</returns>
        public static IEnumerable<IClsItem> GetCls(ClsRoots root)
        {
            return GetCls().Where(x => x.Root == root);
        }
        
        /// <summary>
        /// Возвращает иерархию объектов административно-территориального деления.
        /// </summary>
        /// <returns>Дерево элементов.</returns>
        public static async Task<IEnumerable<ILocation>> GetLocationsAsync()
        {
            var locations = await JSON.JsonContext.GetLocationsAsync();
            return locations;
        }

        /// <summary>
        /// Возвращает перечень всех зданий.
        /// </summary>
        /// <param name="getArchive">Следует ли включать в выборку архивные записи.</param>
        /// <returns>Перечень зданий</returns>
        public static async Task<IEnumerable<IBuilding>> GetBuildingsAsync(bool getArchive = false)
        {
            var _Buildings = await JSON.JsonContext.GetBuildingsAsync();
            return (getArchive) ? _Buildings : _Buildings.Where(x => x.IsArchive == false);
        }

        /// <summary>
        /// Возвращает выборку помещений, расположенных в указанном здании.
        /// </summary>
        /// <param name="building">Здание, помещения которого требуется получить.</param>
        /// <param name="getArchive">Следует ли включать в выборку архивные записи.</param>
        /// <returns>Перечень помещений.</returns>
        public static Task<IEnumerable<IRoom>> GetRoomsAsync(IBuilding building, bool getArchive = false)
        {
            throw new NotImplementedException();
        }

        // обновление сущностей

        // удаление сущностей
    }
}
