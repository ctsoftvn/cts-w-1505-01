using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Data.Domain.Dao;
using CTS.W._150501.Models.Domain.Common.Dao;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Model.Client.Items;
using CTS.Com.Domain.Model;
using CTS.Web.Com.Domain.Helper;
using CTS.Data.Domain.Constants;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Dao.Client
{
    public class MainDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MAINDAO_GETLISTCATEGORIES_SQL = "MainDao_GetListCategories.sql";
        public const string MAINDAO_GETLISTITEMS_SQL = "MainDao_GetListItems.sql";
        public const string MAINDAO_GETITEMDETAIL_SQL = "MainDao_GetItemDetail.sql";
        public const string MAINDAO_GETITEMRELATED_SQL = "MainDao_GetItemRelated.sql";
        public const string MAINDAO_GETCATEGORYINFO_SQL = "MainDao_GetCategoryInfo.sql";
        public const string MAINDAO_GETPAGERDATA_SQL = "MainDao_GetPagerData.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<ItemObject> GetPagerData<T>(T inputObject, object critial) where T : PagerInfoModel<ItemObject>
        {
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<ItemObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = critial;
            // Kết quả trả về
            return GetPagerByFile<ItemObject>(MAINDAO_GETPAGERDATA_SQL, pagerInfo);
        }

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

        public CategoryObject GetCategoryInfo(string localeCd, string linkName)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                LinkName = linkName
            };
            // Kết quả trả về
            return GetObjectByFile<CategoryObject>(MAINDAO_GETCATEGORYINFO_SQL, param);
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
        public ItemObject GetItemDetail(String localeCd, String linkName)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                LinkName = linkName
            };
            // Kết quả trả về
            return GetObjectByFile<ItemObject>(MAINDAO_GETITEMDETAIL_SQL, param);
        }
        public IList<ItemObject> GetListRelations(String localeCd,String itemCd,String categoryCd)
        {
            // Tạo tham số
            var param = new
            {
                LocaleCd = localeCd,
                ItemCd = itemCd,
                CategoryCd = categoryCd
            };
            // Kết quả trả về
            return GetListByFile<ItemObject>(MAINDAO_GETITEMRELATED_SQL, param);
        }

       
    }
}
