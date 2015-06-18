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
using CTS.W._150501.Models.Domain.Model.Admin.Master.Items.List;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Master.Items.List
{
    /// <summary>
    /// SaveBatchLogic
    /// </summary>
    public class SaveBatchLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý save.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SaveBatchDataModel Execute(SaveBatchDataModel inputObject)
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
        private void Check(SaveBatchDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var masterDataCom = new MasterDataCom();
            var seoCom = new SEOCom();
            var msgs = DataHelper.CreateList<Message>();
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(inputObject.ListData)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_MA_ITEMS_00015"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Khởi tạo biến dùng trong loop
            var i = 1;
            // Duyệt danh sách dữ liệu
            foreach (var info in inputObject.ListData) {
                // Khởi tạo biến cục bộ
                var flagError = false;
                // Kiểm tra bắt buộc
                if (DataCheckHelper.IsNull(info.LocaleCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00001", "ADM_MA_ITEMS_00012"));
                }
                if (DataCheckHelper.IsNull(info.ItemCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00001", "ADM_MA_ITEMS_00002"));
                }
                if (DataCheckHelper.IsNull(info.ItemName)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00001", "ADM_MA_ITEMS_00003"));
                }
                if (DataCheckHelper.IsNull(info.LinkName)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00001", "ADM_MA_ITEMS_00005"));
                }
                if (DataCheckHelper.IsNull(info.CategoryCd)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00001", "ADM_MA_ITEMS_00006"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra dữ liệu tồn tại
                var isExist = masterDataCom.IsExistItem(info.LocaleCd, info.ItemCd, true);
                var isExistSEO = seoCom.IsExist(info.LocaleCd, info.ItemCd, W150501Logics.GRPSEO_MA_ITEMS, true);
                if (!isExist || !isExistSEO) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00016", "ADM_MA_ITEMS_00001"));
                }
                // Trường hợp lỗi thì đi đến record tiếp theo
                if (flagError) {
                    // Tăng giá trị i
                    i++;
                    // Đi đến record tiếp theo
                    continue;
                }
                // Kiểm tra giá trị duy nhất
                var isUnique = masterDataCom.IsUniqueItem(info.ItemCd, info.LinkName);
                var comparer = new KeyEqualityComparer<ItemObject>((k1, k2) =>
                        k1.ItemCd != k2.ItemCd
                        && k1.LinkName == k2.LinkName
                );
                // Kiểm tra giá trị duy nhất
                if (!isUnique || inputObject.ListData.Contains(info, comparer)) {
                    flagError = true;
                    msgs.Add(MessageHelper.GetMessageForList(
                        "ADM_MA_ITEMS_00015", i, "E_MSG_00017", "ADM_MA_ITEMS_00005"));
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
        private SaveBatchDataModel SaveInfo(SaveBatchDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var saveResult = new SaveBatchDataModel();
            var processDao = new MasterItemsDao();
            var seoCom = new SEOCom();
            var listUpdate = DataHelper.CreateList<ItemObject>();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, saveResult);
            // Lấy ngôn ngữ chuẩn
            var basicLocale = Logics.LOCALE_DEFAULT;
            // Lấy danh sách thông tin locale chuẩn
            var listBasicLocale = inputObject.ListData.Where(o => o.LocaleCd == basicLocale);
            // Duyệt danh sách thông tin locale chuẩn
            foreach (var info in listBasicLocale) {
                // Thêm vào danh sách cập nhật
                listUpdate.Add(info);
                // Lấy danh sách locale
                var listLocaleDb = processDao.GetListOtherLocale(basicLocale, info.ItemCd);
                // Duyệt danh sách locale
                foreach (var other in listLocaleDb) {
                    // Gán dữ liệu cập nhật
                    other.ItemCd = info.ItemCd;
                    other.CategoryCd = info.CategoryCd;
                    other.LinkName = info.LinkName;
                    other.SortKey = info.SortKey;
                    other.DeleteFlag = info.DeleteFlag;
                    // Thêm vào danh sách cập nhật
                    listUpdate.Add(other);
                }
            }
            // Lấy danh sách thông tin locale
            var listOtherLocale = inputObject.ListData.Where(o => o.LocaleCd != basicLocale);
            // Khởi tạo comparer
            var comparer = new KeyEqualityComparer<ItemObject>((k1, k2) =>
                k1.ItemCd == k2.ItemCd
                && k1.LocaleCd == k2.LocaleCd
            );
            // Duyệt danh sách thông tin locale
            foreach (var info in listOtherLocale) {
                if (listUpdate.Contains(info, comparer)) {
                    // Lấy thông tin cập nhật
                    var updateObj = listUpdate.Single(o =>
                            o.LocaleCd == info.LocaleCd
                            && o.ItemCd == info.ItemCd);
                    var idxObj = listUpdate.IndexOf(updateObj);
                    // Gán dữ liệu cập nhật
                    listUpdate[idxObj].ItemName = info.ItemName;
                    listUpdate[idxObj].SearchName = info.SearchName;
                    listUpdate[idxObj].FileCd = info.FileCd;
                    listUpdate[idxObj].Notes = info.Notes;
                } else {
                    // Thêm vào danh sách cập nhật
                    listUpdate.Add(info);
                }
            }
            // Xử lý tạo transaction
            var transaction = processDao.CreateTransaction();
            // Duyệt danh sách dữ liệu
            foreach (var info in listUpdate) {
                // Xử lý update đối tượng dữ liệu
                processDao.Update(info, transaction);
            }
            // Duyệt danh sách dữ liệu
            foreach (var info in inputObject.ListData) {
                // Xử lý update đối tượng seo
                seoCom.Update(GetSEOInfo(info), transaction);
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
                SEOCd = param.ItemCd,
                GroupCd = W150501Logics.GRPSEO_MA_ITEMS,
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
