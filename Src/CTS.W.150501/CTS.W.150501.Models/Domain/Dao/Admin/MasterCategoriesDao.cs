using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Constants;
using CTS.Data.Domain.Dao;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.W._150501.Models.Domain.Common.Dao;
using CTS.W._150501.Models.Domain.Model.Admin.Master.Categories.List;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Categories;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterCategoriesDao
    /// </summary>
    public class MasterCategoriesDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERCATEGORIESDAO_GETPAGERDATA_SQL = "MasterCategoriesDao_GetPagerData.sql";
        public const string MASTERCATEGORIESDAO_GETLISTLOCALE_SQL = "MasterCategoriesDao_GetListLocale.sql";
        public const string MASTERCATEGORIESDAO_GETLISTOTHERLOCALE_SQL = "MasterCategoriesDao_GetListOtherLocale.sql";
        public const string MASTERCATEGORIESDAO_INSERT_SQL = "MasterCategoriesDao_Insert.sql";
        public const string MASTERCATEGORIESDAO_UPDATE_SQL = "MasterCategoriesDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<CategoryObject> GetPagerData(FilterDataModel inputObject)
        {
            // Tạo tham số
            var param = new {
                ContextLocale = WebContextHelper.LocaleCd,
                LocaleCd = inputObject.LocaleCd,
                CategoryName = inputObject.CategoryName,
                LinkName = inputObject.LinkName,
                DeleteFlag = inputObject.DeleteFlag,
                GrpCdLocales = DataLogics.GRPCD_LOCALES,
                GrpCdDeleteFlag = DataLogics.GRPCD_DELETE_FLAG,
                GrpSeoMaCategories = W150501Logics.GRPSEO_MA_CATEGORIES
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<CategoryObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<CategoryObject>(MASTERCATEGORIESDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<CategoryObject> GetListLocale(string categoryCd)
        {
            // Tạo tham số
            var param = new {
                CategoryCd = categoryCd
            };
            // Kết quả trả về
            return GetListByFile<CategoryObject>(MASTERCATEGORIESDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<CategoryObject> GetListOtherLocale(string localeCd, string categoryCd)
        {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                CategoryCd = categoryCd
            };
            // Kết quả trả về
            return GetListByFile<CategoryObject>(MASTERCATEGORIESDAO_GETLISTOTHERLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(CategoryObject param, DbTransaction transaction)
        {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                CategoryCd = param.CategoryCd,
                CategoryName = param.CategoryName,
                SearchName = param.SearchName,
                LinkName = param.LinkName,
                SortKey = param.SortKey,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERCATEGORIESDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(CategoryObject param, DbTransaction transaction)
        {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                CategoryCd = param.CategoryCd,
                CategoryName = param.CategoryName,
                SearchName = param.SearchName,
                LinkName = param.LinkName,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERCATEGORIESDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}
