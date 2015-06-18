using System.Collections.Generic;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Dao;

namespace CTS.W._150501.Models.Domain.Common.Dao
{
    /// <summary>
    /// MasterDataComDao
    /// </summary>
    public class MasterDataComDao : GenericDao<EntitiesDataContext>
    {
        // Định nghĩa hằng file sql
        public const string MASTERDATACOMDAO_ISUNIQUEITEM_SQL = "MasterDataComDao_IsUniqueItem.sql";
        public const string MASTERDATACOMDAO_GETINFOITEM_SQL = "MasterDataComDao_GetInfoItem.sql";
        public const string MASTERDATACOMDAO_ISUNIQUECATEGORY_SQL = "MasterDataComDao_IsUniqueCategory.sql";
        public const string MASTERDATACOMDAO_GETINFOCATEGORY_SQL = "MasterDataComDao_GetInfoCategory.sql";
        public const string MASTERDATACOMDAO_GETDIVCATEGORY_SQL = "MasterDataComDao_GetDivCategory.sql";

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueItem(string itemCd, string linkName)
        {
            // Tạo tham số
            var param = new {
                ItemCd = itemCd,
                LinkName = linkName
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUEITEM_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MAItem GetInfoItem(string localeCd, string itemCd, bool ignoreDeleteFlag)
        {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                ItemCd = itemCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MAItem>(MASTERDATACOMDAO_GETINFOITEM_SQL, param);
        }

        /// <summary>
        /// Kiểm tra dữ liệu duy nhất
        /// </summary>
        public bool IsUniqueCategory(string categoryCd, string linkName)
        {
            // Tạo tham số
            var param = new {
                CategoryCd = categoryCd,
                LinkName = linkName
            };
            // Kết quả trả về
            var count = GetCountByFile(MASTERDATACOMDAO_ISUNIQUECATEGORY_SQL, param);
            // Kết quả trả về
            return count == 0;
        }

        /// <summary>
        /// Lấy thông tin dữ liệu
        /// </summary>
        public MACategory GetInfoCategory(string localeCd, string categoryCd, bool ignoreDeleteFlag)
        {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                CategoryCd = categoryCd,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetObjectByFile<MACategory>(MASTERDATACOMDAO_GETINFOCATEGORY_SQL, param);
        }

        /// <summary>
        /// Lấy danh sách code
        /// </summary>
        public IList<KeyValueObject> GetDivCategory(string localeCd, string[] skipCodes, bool ignoreDeleteFlag)
        {
            // Tạo tham số
            var param = new {
                LocaleCd = localeCd,
                SkipCodes = skipCodes,
                IgnoreDeleteFlag = ignoreDeleteFlag
            };
            // Kết quả trả về
            return GetListByFile<KeyValueObject>(MASTERDATACOMDAO_GETDIVCATEGORY_SQL, param);
        }
    }
}
