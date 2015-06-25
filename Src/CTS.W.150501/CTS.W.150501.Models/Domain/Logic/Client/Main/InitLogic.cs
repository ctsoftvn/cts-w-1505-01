using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.Main;
using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Com.Domain.Constants;
using CTS.Web.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.Data.MACompanyInfos.Domain.Utils;
using CTS.W._150501.Models.Resources.Strings;
using CTS.Data.APStorageFiles.Domain.Utils;

namespace CTS.W._150501.Models.Domain.Logic.Client.Main
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
            var localeCom = new LocaleCom();
            var companyCom = new CompanyCom();
            var storageFileCom = new StorageFileCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Lấy danh sách ngôn ngữ
            var listLocales = localeCom.GetDiv(DataLogics.CD_APP_CD_CLN, null, false, false);
            // Lấy danh sách menu
            var listMenu = processDao.GetListCategories(WebContextHelper.LocaleCd);
            // Lấy giá trị combo
            var cbLocales = DataHelper.ToComboItems(listLocales, basicLocale);
            // Lấy field
            var companyName = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_COMPANY_NAME, false);
            //var copyright = string.Format(Names.CLN_MASTER_COPYRIGHT, companyName);

            var advertisingFileCd = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_ADVERTISING_FILE, false);
            var advertisingImage = storageFileCom.GetFileName(
                    WebContextHelper.LocaleCd,
                    advertisingFileCd,
                    false);
            if (DataCheckHelper.IsNull(advertisingImage))
            {
                advertisingImage = W150501Logics.PATH_DEFAULT_ADVERTISING_NO_IMAGE;
            }
            else
            {
                advertisingImage = advertisingImage + "_normal";
            }
            var advertisingFileUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_ADVERTISING_URL, false);

            var address1 = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_ADDRESS_1, false);
            var address2 = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_ADDRESS_2, false);

            var slogan = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_SLOGAN, false);
            var hotline = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_HOTLINE, false);

            var twitterUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_TWITTER_URL, false);
            var googleUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_GOOGLE_URL, false);
            var facebookUrl = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_FACEBOOK_URL, false);

            var scriptHeader = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_SCRIPT_HEADER, false);
            var scriptFooter = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_SCRIPT_FOOTER, false);
            // Gán giá trị trả về
            getResult.CboLocales = cbLocales.ListItems;
            getResult.CboLocalesSeleted = cbLocales.SeletedValue;
            getResult.ListMenu = listMenu;

            getResult.CompanyName = companyName;
            getResult.AdvertisingFileCd = advertisingImage;
            getResult.AdvertisingFileUrl = advertisingFileUrl;
            getResult.Address1 = address1;
            getResult.Address2 = address2;
            getResult.Slogan = slogan;
            getResult.Hotline = hotline;
            getResult.TwitterUrl = twitterUrl;
            getResult.FacebookUrl = facebookUrl;
            getResult.GoogleUrl = googleUrl;
            getResult.ScriptHeader = scriptHeader;
            getResult.ScriptFooter = scriptFooter;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
