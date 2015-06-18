using CTS.Com.Domain.Constants;
using CTS.Com.Domain.Helper;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Data.MACodes.Domain.Utils;
using CTS.W._150501.Models.Domain.Common.Utils;
using CTS.W._150501.Models.Domain.Model.Admin.Master.Items.List;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Master.Items.List
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
            var masterDataCom = new MasterDataCom();
            var codeCom = new CodeCom();
            var localeCom = new LocaleCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Lấy giá trị giới hạn trên grid
            var limit = 20;
            // Lấy danh sách code
            var listCategories = masterDataCom.GetDivCategory(basicLocale, null, true, false);
            var listLocales = localeCom.GetDiv(DataLogics.CD_APP_CD_CLN, null, true, false);
            var listDeleteFlag = codeCom.GetDivDeleteFlag(basicLocale, true);
            var listCategoriesGrd = masterDataCom.GetDivCategory(basicLocale, null, false, false);
            var listDeleteFlagGrd = codeCom.GetDivDeleteFlag(basicLocale, false);
            // Lấy giá trị combo
            var cbCategories = DataHelper.ToComboItems(listCategories, string.Empty);
            var cbLocales = DataHelper.ToComboItems(listLocales, string.Empty);
            var cbDeleteFlag = DataHelper.ToComboItems(listDeleteFlag, false);
            var cbCategoriesGrd = DataHelper.ToComboItems(listCategoriesGrd, string.Empty);
            var cbDeleteFlagGrd = DataHelper.ToComboItems(listDeleteFlagGrd, false);
            // Gán giá trị trả về
            getResult.CboCategories = cbCategories.ListItems;
            getResult.CboCategoriesSeleted = cbCategories.SeletedValue;
            getResult.CboLocales = cbLocales.ListItems;
            getResult.CboLocalesSeleted = cbLocales.SeletedValue;
            getResult.CboDeleteFlag = cbDeleteFlag.ListItems;
            getResult.CboDeleteFlagSeleted = cbDeleteFlag.SeletedValueBoolean;
            getResult.CboGrdCategories = cbCategoriesGrd.ListItems;
            getResult.CboGrdDeleteFlag = cbDeleteFlagGrd.ListItems;
            getResult.BasicLocale = basicLocale;
            getResult.Limit = limit;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
