using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.AboutUs;
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
using CTS.W._150501.Models.Resources.Strings;
using CTS.Data.APSEOInfos.Domain.Utils;

namespace CTS.W._150501.Models.Domain.Logic.Client.AboutUs
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
            var companyCom = new CompanyCom();
            var seoCom = new SEOCom();
            var seoInfo = new BaseSEO();
            
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy field
            var aboutUsDescription = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_ABOUTUS_CONTENT, false);
            // Lấy thông tin seo

            var infoSeo = seoCom.GetInfo(WebContextHelper.LocaleCd, W150501Logics.CD_SEO_CD_PAGE_ABOUT, W150501Logics.GRPSEO_CLN_PAGES, false);
            seoInfo.MetaTitle = infoSeo.MetaTitle;
            seoInfo.MetaKeys = infoSeo.MetaKeys;
            seoInfo.MetaDesc = infoSeo.MetaDesc;
            // Gán giá trị trả về
            getResult.AboutUsDescription = aboutUsDescription;
            getResult.MetaTitle = seoInfo.MetaTitle;
            getResult.MetaKey = seoInfo.MetaKeys;
            getResult.MetaDescription = seoInfo.MetaDesc;

            // Kết quả trả về
            return getResult;
            
        }
        #endregion
    }
}
