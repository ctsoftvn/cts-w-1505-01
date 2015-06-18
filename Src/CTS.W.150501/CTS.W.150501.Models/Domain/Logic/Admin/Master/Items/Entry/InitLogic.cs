using CTS.Com.Domain.Constants;
using CTS.Com.Domain.Exceptions;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.APSEOInfos.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Data.Domain.Entity;
using CTS.Data.MACodes.Domain.Utils;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.W._150501.Models.Domain.Common.Utils;
using CTS.W._150501.Models.Domain.Dao.Admin;
using CTS.W._150501.Models.Domain.Model.Admin.Master.Items.Entry;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Master.Items.Entry
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
            var masterDataCom = new MasterDataCom();
            var msgs = DataHelper.CreateList<Message>();
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Trường hợp status là edit
            if (inputObject.IsEdit) {
                if (DataCheckHelper.IsNull(inputObject.ItemCd)) {
                    msgs.Add(MessageHelper.GetMessage("E_MSG_00013", "ADM_MA_ITEMS_00002"));
                }
                // Kiểm tra danh sách lỗi
                if (!DataCheckHelper.IsNull(msgs)) {
                    throw new ExecuteException(msgs);
                }
                // Kiểm tra dữ liệu tồn tại
                var isExist = masterDataCom.IsExistItem(basicLocale, inputObject.ItemCd, true);
                if (!isExist) {
                    msgs.Add(MessageHelper.GetMessage("E_MSG_00016", "ADM_MA_ITEMS_00001"));
                }
                // Kiểm tra danh sách lỗi
                if (!DataCheckHelper.IsNull(msgs)) {
                    throw new ExecuteException(msgs);
                }
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
            var processDao = new MasterItemsDao();
            var masterDataCom = new MasterDataCom();
            var codeCom = new CodeCom();
            var localeCom = new LocaleCom();
            var localeModel = new LocaleModel<ItemObject>();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Trường hợp status là edit hoặc copy
            if (inputObject.IsEdit || inputObject.IsCopy) {
                // Khởi tạo biến cục bộ
                var seoCom = new SEOCom();
                var listData = DataHelper.CreateList<ItemObject>();
                // Lấy danh sách dữ liệu đa ngôn ngữ
                var listLocale = processDao.GetListLocale(inputObject.ItemCd);
                // Khởi tạo biến dùng trong loop
                var rowNo = 0;
                var localeName = string.Empty;
                SEOInfo metaInfo = null;
                // Duyệt danh sách dữ liệu đa ngôn ngữ
                foreach (var info in listLocale) {
                    // Lấy thông tin tên
                    localeName = localeCom.GetName(DataLogics.CD_APP_CD_CLN, info.LocaleCd, false);
                    // Lấy thông tin SEO
                    metaInfo = seoCom.GetInfo(info.LocaleCd, info.ItemCd, W150501Logics.GRPSEO_MA_ITEMS, true);
                    // Lấy số dòng
                    if (info.LocaleCd != basicLocale) {
                        info.RowNo = rowNo++;
                    }
                    // Gán thông tin dữ liệu
                    info.LocaleName = localeName;
                    info.MetaTitle = metaInfo.MetaTitle;
                    info.MetaDesc = metaInfo.MetaDesc;
                    info.MetaKeys = metaInfo.MetaKeys;
                    // Thêm vào danh sách kết quả
                    listData.Add(info);
                }
                // Tiến hành convert đối tượng locale
                localeModel = DataHelper.ToLocaleModel(basicLocale, listData);
            }
            // Khởi tạo giá trị init
            if (inputObject.IsAdd) {
                localeModel.DataInfo.ItemCd = string.Empty;
                localeModel.DataInfo.ItemName = string.Empty;
                localeModel.DataInfo.LocaleCd = basicLocale;
                localeModel.DataInfo.SortKey = decimal.One;
                localeModel.ListLocale.Clear();
            }
            // Lấy danh sách code
            var listCategories = masterDataCom.GetDivCategory(basicLocale, null, false, false);
            var listLocales = localeCom.GetDiv(DataLogics.CD_APP_CD_CLN, basicLocale, false, false);
            var listDeleteFlag = codeCom.GetDivDeleteFlag(basicLocale, false);
            // Lấy giá trị combo
            var cbCategories = DataHelper.ToComboItems(listCategories, localeModel.DataInfo.CategoryCd);
            var cbLocales = DataHelper.ToComboItems(listLocales, string.Empty);
            var cbDeleteFlag = DataHelper.ToComboItems(listDeleteFlag, localeModel.DataInfo.DeleteFlag);
            // Gán giá trị trả về
            getResult.LocaleModel = localeModel;
            getResult.CboCategories = cbCategories.ListItems;
            getResult.LocaleModel.DataInfo.CategoryCd = cbCategories.SeletedValue;
            getResult.CboLocales = cbLocales.ListItems;
            getResult.CboLocalesSeleted = cbLocales.SeletedValue;
            getResult.CboDeleteFlag = cbDeleteFlag.ListItems;
            getResult.LocaleModel.DataInfo.DeleteFlag = cbDeleteFlag.SeletedValueBoolean;

            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
