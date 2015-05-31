using System.Collections.Generic;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Constants;
using CTS.W._150501.Models.Domain.Common.Dao;

namespace CTS.W._150501.Models.Domain.Common.Utils
{
    /// <summary>
    /// MasterDataCom
    /// </summary>
    public class MasterDataCom
    {
        private readonly MasterDataComDao _comDao;
        public MasterDataCom() { _comDao = new MasterDataComDao(); }

        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistItem(string localeCd, string itemCd, bool ignoreDeleteFlag)
        {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(itemCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoItem(localeCd, itemCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueItem(string itemCd, string linkName)
        {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(itemCd)
                || DataCheckHelper.IsNull(linkName)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueItem(itemCd, linkName);
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAItem GetInfoItem(string localeCd, string itemCd, bool ignoreDeleteFlag)
        {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(itemCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoItem(localeCd, itemCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Kiểm tra dữ liệu tồn tại
        /// </summary>
        public bool IsExistCategory(string localeCd, string categoryCd, bool ignoreDeleteFlag)
        {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(categoryCd)) {
                return true;
            }
            // Lấy thông tin dữ liệu
            var dataInfo = GetInfoCategory(localeCd, categoryCd, ignoreDeleteFlag);
            // Kết quả trả về
            return dataInfo != null;
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueCategory(string categoryCd, string linkName)
        {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(categoryCd)
                || DataCheckHelper.IsNull(linkName)) {
                return true;
            }
            // Kết quả trả về
            return _comDao.IsUniqueCategory(categoryCd, linkName);
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MACategory GetInfoCategory(string localeCd, string categoryCd, bool ignoreDeleteFlag)
        {
            // Trường hợp tham số là null
            if (DataCheckHelper.IsNull(localeCd)
                || DataCheckHelper.IsNull(categoryCd)) {
                return null;
            }
            // Kết quả trả về
            return _comDao.GetInfoCategory(localeCd, categoryCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Lấy danh sách code
        /// </summary>
        public IList<KeyValueObject> GetDivCategory(string localeCd, string skipCode, bool nullValue, bool ignoreDeleteFlag)
        {
            // Khởi tạo biến cục bộ
            var skipCodes = new string[0];
            var listResult = new List<KeyValueObject>();
            // Lấy danh sách skip code trong trường hợp skip code khác null
            if (skipCode != null) {
                skipCodes = skipCode.Split(DataLogics.DELIMITER_SKIP_CODE);
            }
            // Tạo giá trị trắng trong trường hợp có thêm giá trị trắng
            if (nullValue) {
                listResult.Add(new KeyValueObject());
            }
            // Lấy danh sách code
            var listData = _comDao.GetDivCategory(localeCd, skipCodes, ignoreDeleteFlag);
            // Thêm danh sách code vào danh sách kết quả
            listResult.AddRange(listData);
            // Kết quả trả về
            return listResult;
        }
    }
}
