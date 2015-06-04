using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Data.Domain.Dao;
using CTS.W._150501.Models.Domain.Common.Dao;
using CTS.W._150501.Models.Domain.Object.Client.Main;

namespace CTS.W._150501.Models.Domain.Dao.Client
{
    public class MainDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MAINDAO_GETLISTCATEGORIES_SQL = "MainDao_GetListCategories.sql";
        public const string MAINDAO_GETLISTITEMS_SQL = "MainDao_GetListItems.sql";
        public const string MAINDAO_GETITEMDETAIL_SQL = "MainDao_GetItemDetail.sql";
        public const string MAINDAO_GETITEMRELATED_SQL = "MainDao_GetItemRelated.sql";

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<CategoryObject> GetListCategories(String localeCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd
            };
            // Kết quả trả về
            return GetListByFile<CategoryObject>(MAINDAO_GETLISTCATEGORIES_SQL, param);
        }
        public IList<ItemObject> GetListItems(String localeCd, String categoryCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                CategoryCd = categoryCd
            };
            // Kết quả trả về
            return GetListByFile<ItemObject>(MAINDAO_GETLISTITEMS_SQL, param);
        }
        public ItemObject GetItems(String localeCd, String itemCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                ItemCd = itemCd
            };
            // Kết quả trả về
            return GetObjectByFile<ItemObject>(MAINDAO_GETITEMDETAIL_SQL, param);
        }
        public IList<ItemObject> GetListRelations(ItemObject item )
        {
            // Tạo tham số
            var param = new
            {
                
            };
            // Kết quả trả về
            return GetListByFile<ItemObject>(MAINDAO_GETITEMRELATED_SQL, param);
        }
    }
}
