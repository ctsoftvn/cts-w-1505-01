using System;
using System.Linq;
using CTS.Com.Domain.Constants;
using CTS.Com.Domain.Exceptions;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Com.Domain.Utils;
using CTS.Data.APSEOInfos.Domain.Utils;
using CTS.Data.Domain.Entity;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.W._150501.Models.Domain.Common.Utils;
using CTS.W._150501.Models.Domain.Dao.Admin;
using CTS.W._150501.Models.Domain.Model.Admin.Master.Items.Entry;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Master.Items.Entry
{
    /// <summary>
    /// SaveLogic
    /// </summary>
    public class SaveLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý save.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SaveDataModel Execute(SaveDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lưu thông tin
            var resultObject = SaveInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(SaveDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            var seoCom = new SEOCom();
            var msgs = DataHelper.CreateList<Message>();
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Lấy đối tượng dữ liệu
            var dataInfo = inputObject.LocaleModel.DataInfo;
            var listLocale = inputObject.LocaleModel.ListLocale;
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(dataInfo.LocaleCd)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_ITEMS_00012"));
            }
            if (DataCheckHelper.IsNull(dataInfo.ItemCd)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_ITEMS_00002"));
            }
            if (DataCheckHelper.IsNull(dataInfo.ItemName)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_ITEMS_00003"));
            }
            if (DataCheckHelper.IsNull(dataInfo.LinkName)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_ITEMS_00005"));
            }
            if (DataCheckHelper.IsNull(dataInfo.CategoryCd)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_ITEMS_00006"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra locale hợp lệ
            if (dataInfo.LocaleCd != basicLocale) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00030"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra dữ liệu tồn tại
            var isExist = masterDataCom.IsExistItem(dataInfo.LocaleCd, dataInfo.ItemCd, true);
            var isExistSEO = seoCom.IsExist(dataInfo.LocaleCd, dataInfo.ItemCd, W150501Logics.GRPSEO_MA_ITEMS, true);
            // Kiểm tra dữ liệu tồn tại trường hợp status là add
            if (inputObject.IsAdd && (isExist || isExistSEO)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00017", "ADM_MA_ITEMS_00001"));
            }
            // Kiểm tra dữ liệu tồn tại trường hợp status là edit
            if (inputObject.IsEdit && (!isExist || !isExistSEO)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00016", "ADM_MA_ITEMS_00001"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra giá trị duy nhất
            var isUnique = masterDataCom.IsUniqueItem(dataInfo.ItemCd, dataInfo.LinkName);
            // Kiểm tra giá trị duy nhất
            if (!isUnique) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00017", "ADM_MA_ITEMS_00005"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Khởi tạo biến dùng trong loop
            var i = 1;
            var flagError = false;
            // Duyệt danh sách ngôn ngữ
            foreach (var info in listLocale) {
                // Gán trạng thái lỗi bằng false
                flagError = false;
                // Kiểm tra bắt buộc
                if (DataCheckHelper.IsNull(info.LocaleCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00014", i, "E_MSG_00001", "ADM_MA_ITEMS_00012"));
                }
                if (DataCheckHelper.IsNull(info.ItemName)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00014", i, "E_MSG_00001", "ADM_MA_ITEMS_00003"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra giá trị duy nhất
                var comparer = new KeyEqualityComparer<ItemObject>((k1, k2) =>
                        k1.RowNo != k2.RowNo
                        && k1.LocaleCd == k2.LocaleCd
                );
                if (dataInfo.LocaleCd == info.LocaleCd || listLocale.Contains(info, comparer)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00014", i, "E_MSG_00017", "ADM_MA_ITEMS_00012"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Tăng giá trị i
                i++;
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
        }

        /// <summary>
        /// Lưu thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SaveDataModel SaveInfo(SaveDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var saveResult = new SaveDataModel();
            var processDao = new MasterItemsDao();
            var seoCom = new SEOCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, saveResult);
            // Lấy đối tượng dữ liệu
            var dataInfo = inputObject.LocaleModel.DataInfo;
            var listLocale = inputObject.LocaleModel.ListLocale;
            // Lấy danh sách dữ liệu đa ngôn ngữ
            var listLocaleDb = processDao.GetListLocale(dataInfo.ItemCd);
            // Khởi tạo comparer
            var comparer = new KeyEqualityComparer<ItemObject>((k1, k2) =>
                k1.ItemCd == k2.ItemCd
                && k1.LocaleCd == k2.LocaleCd
            );
            // Xử lý tạo transaction
            var transaction = processDao.CreateTransaction();
            // Lưu đối tượng dữ liệu
            if (inputObject.IsAdd) {
                // Xử lý insert đối tượng dữ liệu
                processDao.Insert(dataInfo, transaction);
                seoCom.Insert(GetSEOInfo(dataInfo), transaction);
                // Duyệt danh sách locale
                foreach (var info in listLocale) {
                    // Gán dữ liệu cập nhật
                    info.ItemCd = dataInfo.ItemCd;
                    info.CategoryCd = dataInfo.CategoryCd;
                    info.LinkName = dataInfo.LinkName;
                    info.SortKey = dataInfo.SortKey;
                    info.DeleteFlag = dataInfo.DeleteFlag;
                    // Xử lý insert đối tượng dữ liệu
                    processDao.Insert(info, transaction);
                    seoCom.Insert(GetSEOInfo(info), transaction);
                }
            } else {
                // Xử lý update đối tượng dữ liệu
                processDao.Update(dataInfo, transaction);
                seoCom.Update(GetSEOInfo(dataInfo), transaction);
                // Duyệt danh sách locale
                foreach (var info in listLocale) {
                    // Gán dữ liệu cập nhật
                    info.ItemCd = dataInfo.ItemCd;
                    info.CategoryCd = dataInfo.CategoryCd;
                    info.LinkName = dataInfo.LinkName;
                    info.SortKey = dataInfo.SortKey;
                    info.DeleteFlag = dataInfo.DeleteFlag;
                    // Trường hợp không tồn tại dữ liệu
                    if (listLocaleDb.Contains(info, comparer)) {
                        // Xử lý update đối tượng dữ liệu
                        processDao.Update(info, transaction);
                        seoCom.Update(GetSEOInfo(info), transaction);
                    } else {
                        // Xử lý insert đối tượng dữ liệu
                        processDao.Insert(info, transaction);
                        seoCom.Insert(GetSEOInfo(info), transaction);
                    }
                }
            }
            // Xử lý lưu các thay đổi từ transaction
            processDao.CommitTransaction(transaction);
            // Thêm thông báo thành công
            saveResult.AddMessage("I_MSG_00004");
            // Kết quả trả về
            return saveResult;
        }

        /// <summary>
        /// Lấy đối tượng SEO
        /// </summary>
        private SEOInfo GetSEOInfo(ItemObject param)
        {
            // Khởi tạo biến cục bộ
            var sysDate = DateTime.Now;
            // Kết quả trả về
            var info = new SEOInfo() {
                LocaleCd = param.LocaleCd,
                GroupCd = W150501Logics.GRPSEO_MA_ITEMS,
                SEOCd = param.ItemCd,
                SEOName = string.Empty,
                MetaTitle = param.MetaTitle,
                MetaDesc = param.MetaDesc,
                MetaKeys = param.MetaKeys,
                CreateUser = WebContextHelper.UserName,
                CreateDate = sysDate,
                UpdateUser = WebContextHelper.UserName,
                UpdateDate = sysDate,
                DeleteFlag = param.DeleteFlag
            };
            // Kết quả trả về
            return info;
        }
        #endregion
    }
}
