using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.Items;
using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Web.Com.Domain.Helper;
using CTS.Data.APStorageFiles.Domain.Utils;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.Com.Domain.Exceptions;
using CTS.Data.APSEOInfos.Domain.Utils;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Logic.Client.Items
{
    /// <summary>
    /// InitLogic
    /// </summary>
    public class InitLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý init.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public InitDataModel Execute(InitDataModel inputObject)
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
        private void Check(InitDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var processDao = new MainDao();
            // Lấy thông tin sản phẩm
            var categoryInfo = processDao.GetCategoryInfo(WebContextHelper.LocaleCd, inputObject.LinkName);
            // Kiểm tra dữ liệu tồn tại
            if (categoryInfo == null && !DataCheckHelper.IsNull(inputObject.LinkName))
            {
                throw new ExecuteException("I_MSG_00008");
            }
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new InitDataModel();
            var processDao = new MainDao();
            var storageFileCom = new StorageFileCom();
            var seoCom = new SEOCom();
            var categoryCd = string.Empty;
            var seoInfo = new BaseSEO();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin loại
            var categoryInfo = processDao.GetCategoryInfo(WebContextHelper.LocaleCd, inputObject.LinkName);
            if (categoryInfo != null)
            {
                categoryCd = categoryInfo.CategoryCd;
            }
            // Lấy danh sách menu
            var listItems = processDao.GetListItems(WebContextHelper.LocaleCd, categoryCd);
            foreach (var item in listItems)
            {
                item.ItemImage = storageFileCom.GetFileName(
                    WebContextHelper.LocaleCd,
                    item.FileCd,
                    false);
                if (DataCheckHelper.IsNull(item.ItemImage))
                {
                    item.ItemImage = W150501Logics.PATH_DEFAULT_NO_IMAGE;
                }

            }
            // Lấy thông tin seo
            if (DataCheckHelper.IsNull(categoryCd))
            {
                var info = seoCom.GetInfo(WebContextHelper.LocaleCd, W150501Logics.CD_SEO_CD_PAGE_INDEX, W150501Logics.GRPSEO_CLN_PAGES, false);
                seoInfo.MetaTitle = info.MetaTitle;
                seoInfo.MetaKeys = info.MetaKeys;
                seoInfo.MetaDesc = info.MetaDesc;
            }
            else
            {
                var info = seoCom.GetInfo(WebContextHelper.LocaleCd, categoryCd, W150501Logics.GRPSEO_MA_CATEGORIES, false);
                seoInfo.MetaTitle = info.MetaTitle;
                seoInfo.MetaKeys = info.MetaKeys;
                seoInfo.MetaDesc = info.MetaDesc;
            }

            // Gán giá trị trả về
            getResult.ListItems = listItems;
            getResult.MetaTitle = seoInfo.MetaTitle;
            getResult.MetaKey = seoInfo.MetaKeys;
            getResult.MetaDescription = seoInfo.MetaDesc;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
