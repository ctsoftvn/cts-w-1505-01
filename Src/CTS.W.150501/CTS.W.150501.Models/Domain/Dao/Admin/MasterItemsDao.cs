using System;
using System.Collections.Generic;
using System.Data.Common;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Dao;
using CTS.W._150501.Models.Domain.Common.Dao;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Dao.Admin
{
    /// <summary>
    /// MasterItemsDao
    /// </summary>
    public class MasterItemsDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERITEMSDAO_GETPAGERDATA_SQL = "MasterItemsDao_GetPagerData.sql";
        public const string MASTERITEMSDAO_SAVEBATCH_SQL = "MasterItemsDao_SaveBatch.sql";
        public const string MASTERITEMSDAO_GETLISTLOCALE_SQL = "MasterItemsDao_GetListLocale.sql";
        public const string MASTERITEMSDAO_INSERT_SQL = "MasterItemsDao_Insert.sql";
        public const string MASTERITEMSDAO_UPDATE_SQL = "MasterItemsDao_Update.sql";

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        public PagerInfoModel<ItemObject> GetPagerData(object inputObject) //FilterDataModel inputObject)
        {
            // Tạo tham số
            var param = new {
                // ItemCd = inputObject.ItemCd,
                // ItemName = inputObject.ItemName
            };
            // Tạo đối tượng pager
            var pagerInfo = new PagerInfoModel<ItemObject>();
            // Sao chép thông tin pager
            DataHelper.CopyPagerInfo(inputObject, pagerInfo);
            // Gán tham số
            pagerInfo.Critial = param;
            // Kết quả trả về
            return GetPagerByFile<ItemObject>(MASTERITEMSDAO_GETPAGERDATA_SQL, pagerInfo);
        }

        /// <summary>
        /// Lưu danh sách thay đổi
        /// </summary>
        public int SaveBatch(IList<ItemObject> listData)
        {
            // Kết thúc xử lý
            return UpdateBatchByFile(MASTERITEMSDAO_SAVEBATCH_SQL, listData);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu đa ngôn ngữ
        /// </summary>
        public IList<ItemObject> GetListLocale(string itemCd)
        {
            // Tạo tham số
            var param = new {
                ItemCd = itemCd
            };
            // Kết quả trả về
            return GetListByFile<ItemObject>(MASTERITEMSDAO_GETLISTLOCALE_SQL, param);
        }

        /// <summary>
        /// Thêm thông tin dữ liệu
        /// </summary>
        public int Insert(ItemObject param, DbTransaction transaction)
        {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var insertObj = new {
                LocaleCd = param.LocaleCd,
                ItemCd = param.ItemCd,
                ItemName = param.ItemName,
                SearchName = param.SearchName,
                LinkName = param.LinkName,
                CategoryCd = param.CategoryCd,
                Notes = param.Notes,
                SortKey = param.SortKey,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERITEMSDAO_INSERT_SQL, insertObj, transaction);
        }

        /// <summary>
        /// Cập nhật thông tin dữ liệu
        /// </summary>
        public int Update(ItemObject param, DbTransaction transaction)
        {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Tạo tham số
            var updateObj = new {
                LocaleCd = param.LocaleCd,
                ItemCd = param.ItemCd,
                ItemName = param.ItemName,
                SearchName = param.SearchName,
                LinkName = param.LinkName,
                CategoryCd = param.CategoryCd,
                Notes = param.Notes,
                SortKey = param.SortKey,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Tiến hành thêm đối tượng dữ liệu
            return UpdateByFile(MASTERITEMSDAO_UPDATE_SQL, updateObj, transaction);
        }
    }
}
