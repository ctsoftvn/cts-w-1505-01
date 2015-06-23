using CTS.Com.Domain.Constants;
using CTS.Com.Domain.Helper;
using CTS.Data.Domain.Constants;
using CTS.Data.MACodes.Domain.Utils;
using CTS.Data.MAParameters.Domain.Utils;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.W._150501.Models.Domain.Model.Admin.Master.Categories.List;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Master.Categories.List
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
            var codeCom = new CodeCom();
            var parameterCom = new ParameterCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Lấy giá trị giới hạn trên grid
            var limit = parameterCom.GetNumber(W150501Logics.CD_PARAM_CD_ADM_LIMIT, false);
            // Lấy danh sách code
            var listLocales = codeCom.GetDiv(basicLocale, DataLogics.GRPCD_LOCALES, null, true, false);
            var listDeleteFlag = codeCom.GetDivDeleteFlag(basicLocale, true);
            var listDeleteFlagGrd = codeCom.GetDivDeleteFlag(basicLocale, false);
            // Lấy giá trị combo
            var cbLocales = DataHelper.ToComboItems(listLocales, string.Empty);
            var cbDeleteFlag = DataHelper.ToComboItems(listDeleteFlag, false);
            var cbDeleteFlagGrd = DataHelper.ToComboItems(listDeleteFlagGrd, false);
            // Gán giá trị trả về
            getResult.CboLocales = cbLocales.ListItems;
            getResult.CboLocalesSeleted = cbLocales.SeletedValue;
            getResult.CboDeleteFlag = cbDeleteFlag.ListItems;
            getResult.CboDeleteFlagSeleted = cbDeleteFlag.SeletedValueBoolean;
            getResult.CboGrdDeleteFlag = cbDeleteFlagGrd.ListItems;
            getResult.BasicLocale = basicLocale;
            getResult.Limit = limit;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
