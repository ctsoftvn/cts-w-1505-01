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
using CTS.Data.MACompanyInfos.Domain.Utils;
using CTS.Data.MAParameters.Domain.Utils;

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
            //var storageFileCom = new StorageFileCom();
            var seoCom = new SEOCom();
            var categoryCd = string.Empty;
            var seoInfo = new BaseSEO();
            var storageFileCom = new StorageFileCom();
            var parameterCom = new ParameterCom();
            // Lấy giá trị giới hạn trên grid
            var limit = parameterCom.GetNumber(W150501Logics.CD_PARAM_CD_CLN_LIMIT, false);
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin loại
            var categoryInfo = processDao.GetCategoryInfo(WebContextHelper.LocaleCd, inputObject.LinkName);
            if (categoryInfo != null)
            {
                categoryCd = categoryInfo.CategoryCd;
            }
            // Lấy danh sách menu
            inputObject.CategoryCd = categoryCd;
            inputObject.Limit = limit.Value;
            // Lấy đối tượng pager
            var pagerData = GetPagerData(inputObject);

            // Lấy thông tin seo
            if (DataCheckHelper.IsNull(categoryCd))
            {
                var info = seoCom.GetInfo(WebContextHelper.LocaleCd, W150501Logics.CD_SEO_CD_PAGE_INDEX, W150501Logics.GRPSEO_CLN_PAGES, false);
                if (info != null)
                {
                    seoInfo.MetaTitle = info.MetaTitle;
                    seoInfo.MetaKeys = info.MetaKeys;
                    seoInfo.MetaDesc = info.MetaDesc;
                }
            }
            else
            {
                var info = seoCom.GetInfo(WebContextHelper.LocaleCd, categoryCd, W150501Logics.GRPSEO_MA_CATEGORIES, false);
                if (info != null)
                {
                    seoInfo.MetaTitle = info.MetaTitle;
                    seoInfo.MetaKeys = info.MetaKeys;
                    seoInfo.MetaDesc = info.MetaDesc;
                }
            }

            // Gán giá trị trả về
            getResult.ListData = pagerData.ListData;
            getResult.Total = pagerData.Total;
            getResult.MetaTitle = seoInfo.MetaTitle;
            getResult.MetaKey = seoInfo.MetaKeys;
            getResult.MetaDescription = seoInfo.MetaDesc;
            getResult.CategoryCd = categoryCd;
            getResult.LimitPager = limit;
            // Kết quả trả về
            return getResult;
        }

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        private PagerInfoModel<ItemObject> GetPagerData(InitDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var pagerResult = new PagerInfoModel<ItemObject>();
            var processDao = new MainDao();
            var storageFileCom = new StorageFileCom();
            // Tạo tham số
            var critial = new
            {
                LocaleCd = WebContextHelper.LocaleCd,
                CategoryCd = inputObject.CategoryCd
            };
            // Lấy đối tượng pager
            var pagerData = processDao.GetPagerData(inputObject, critial);
            foreach (var item in pagerData.ListData)
            {
                item.ItemImage = storageFileCom.GetFileName(
                    WebContextHelper.LocaleCd,
                    item.FileCd,
                    false);
                if (DataCheckHelper.IsNull(item.ItemImage))
                {
                    item.ItemImage = W150501Logics.PATH_DEFAULT_NO_IMAGE;
                }
                else {
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
