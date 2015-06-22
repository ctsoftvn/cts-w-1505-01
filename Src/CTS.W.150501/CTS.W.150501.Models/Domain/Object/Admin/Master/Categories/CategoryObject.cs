using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Object.Admin.Master.Categories
{
    /// <summary>
    /// CategoryObject
    /// </summary>
    public class CategoryObject : BaseSEO
    {
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "rowNo", MessageParam = "ADM_MA_CATEGORIES_00010")]
        public decimal? RowNo { get; set; }
        [OutputText]
        [InputText(RuleName = "localeCd", MessageParam = "ADM_MA_CATEGORIES_00002")]
        public string LocaleCd { get; set; }
        [OutputText]
        [InputText(RuleName = "code", MessageParam = "ADM_MA_CATEGORIES_00003")]
        public string CategoryCd { get; set; }
        [OutputText]
        [InputText(RuleName = "name", MessageParam = "ADM_MA_CATEGORIES_00004")]
        public string CategoryName { get; set; }
        [OutputText]
        [InputText(RuleName = "searchName", MessageParam = "ADM_MA_CATEGORIES_00005")]
        public string SearchName { get; set; }
        [OutputText]
        [InputText(RuleName = "linkName", MessageParam = "ADM_MA_CATEGORIES_00006")]
        public string LinkName { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "sortKey", MessageParam = "ADM_MA_CATEGORIES_00007")]
        public decimal? SortKey { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "versionNo", MessageParam = "ADM_MA_CATEGORIES_00008")]
        public decimal? VersionNo { get; set; }
        [OutputText]
        [InputText(RuleName = "boolean", MessageParam = "ADM_MA_CATEGORIES_00009")]
        public bool? DeleteFlag { get; set; }

        [OutputText]
        public string LocaleName { get; set; }
        [OutputText]
        public string DeleteFlagName { get; set; }
    }
}
