﻿using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.APStorageFiles.Domain.Utils;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.W._150501.Models.Domain.Model.Client.Items;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Logic.Client.Items
{
    /// <summary>
    /// FilterLogic
    /// </summary>
    public class FilterLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý filter.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public FilterDataModel Execute(FilterDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
            var resultObject = GetInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(FilterDataModel inputObject)
        {
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new FilterDataModel();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy đối tượng pager
            var pagerData = GetPagerData(inputObject);
            // Gán giá trị trả về
            getResult.ListData = pagerData.ListData;
            getResult.Total = pagerData.Total;
            // Kết quả trả về
            return getResult;
        }

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        private PagerInfoModel<ItemObject> GetPagerData(FilterDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var pagerResult = new PagerInfoModel<ItemObject>();
            var processDao = new MainDao();
            var storageFileCom = new StorageFileCom();
            // Tạo tham số
            var critial = new {
                LocaleCd = WebContextHelper.LocaleCd,
                CategoryCd = inputObject.CategoryCd
            };
            // Lấy đối tượng pager
            var pagerData = processDao.GetPagerData(inputObject, critial);
            foreach (var item in pagerData.ListData) {
                item.ItemImage = storageFileCom.GetFileName(
                    WebContextHelper.LocaleCd,
                    item.FileCd,
                    false);
                if (DataCheckHelper.IsNull(item.ItemImage)) {
                    item.ItemImage = W150501Logics.PATH_DEFAULT_NO_IMAGE;
                } else {
                    item.ItemImage = item.ItemImage + "_normal";
                }
            }
            // Gán giá trị trả về
            pagerResult.ListData = pagerData.ListData;
            pagerResult.Total = pagerData.Total;
            // Kết quả trả về
            return pagerResult;
        }
        #endregion
    }
}