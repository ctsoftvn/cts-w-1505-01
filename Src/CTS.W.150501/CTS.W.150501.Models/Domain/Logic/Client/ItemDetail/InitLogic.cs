using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.ItemDetail;
using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Web.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.Data.APStorageFiles.Domain.Utils;
using CTS.Com.Domain.Constants;
using CTS.Com.Domain.Exceptions;
using CTS.Com.Domain.Model;
using CTS.Data.MACompanyInfos.Domain.Utils;
using CTS.Data.APSEOInfos.Domain.Utils;

namespace CTS.W._150501.Models.Domain.Logic.Client.ItemDetail
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
            var item = processDao.GetItemDetail(WebContextHelper.LocaleCd, inputObject.LinkName);
            // Kiểm tra dữ liệu tồn tại
            if (item == null)
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
            var storageFileCom = new StorageFileCom();
            var processDao = new MainDao();
            var seoCom = new SEOCom();
            var seoInfo = new BaseSEO();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy item
            var item = processDao.GetItemDetail(WebContextHelper.LocaleCd, inputObject.LinkName);
            // Lấy related item
            var listRelations = processDao.GetListRelations(WebContextHelper.LocaleCd, item.ItemCd, item.CategoryCd);
            foreach (var info in listRelations)
            {
                info.ItemImage = storageFileCom.GetFileName(
                    WebContextHelper.LocaleCd,
                    info.FileCd,
                    false);
                if (DataCheckHelper.IsNull(info.ItemImage))
                {
                    info.ItemImage = W150501Logics.PATH_DEFAULT_NO_IMAGE;
                }

            }
            // Lấy thông tin seo

            var infoSeo = seoCom.GetInfo(WebContextHelper.LocaleCd, W150501Logics.GRPSEO_MA_ITEMS, item.ItemCd, false);
            seoInfo.MetaTitle = infoSeo.MetaTitle;
            seoInfo.MetaKeys = infoSeo.MetaKeys;
            seoInfo.MetaDesc = infoSeo.MetaDesc;

            // Gán giá trị trả về
            getResult.Item = item;
            getResult.ListRelations = listRelations;
            getResult.MetaTitle = seoInfo.MetaTitle;
            getResult.MetaKey = seoInfo.MetaKeys;
            getResult.MetaDescription = seoInfo.MetaDesc;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
