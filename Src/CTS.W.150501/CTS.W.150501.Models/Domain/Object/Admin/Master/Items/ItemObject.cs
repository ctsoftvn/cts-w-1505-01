﻿using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Object.Admin.Master.Items
{
    public class ItemObject : BaseSEO
    {
        [OutputText]
        [InputText(RuleName = "rowNo", MessageParam = "ADM_MA_ITEMS_ENTRY_00014")]
        public int RowNo { get; set; }
        [OutputText]
        [InputText(RuleName = "localeCd", MessageParam = "ADM_MA_ITEMS_ENTRY_00012")]
        public string LocaleCd { get; set; }
        [OutputText]
        [InputText(RuleName = "code", MessageParam = "ADM_MA_ITEMS_ENTRY_00002")]
        public string ItemCd { get; set; }
        [OutputText]
        [InputText(RuleName = "name", MessageParam = "ADM_MA_ITEMS_ENTRY_00003")]
        public string ItemName { get; set; }
        [OutputText]
        [InputText(RuleName = "searchName", MessageParam = "ADM_MA_ITEMS_ENTRY_00004")]
        public string SearchName { get; set; }
        [OutputText]
        [InputText(RuleName = "linkName", MessageParam = "ADM_MA_ITEMS_ENTRY_00005")]
        public string LinkName { get; set; }
        [OutputText]
        [InputText(RuleName = "code", MessageParam = "ADM_MA_ITEMS_ENTRY_00006")]
        public string CategoryCd { get; set; }
        [OutputText]
        [InputText(RuleName = "fileCd", MessageParam = "ADM_MA_ITEMS_ENTRY_00007")]
        public string FileCd { get; set; }
        [OutputText]
        [InputText(RuleName = "notes", MessageParam = "ADM_MA_ITEMS_ENTRY_00008")]
        public string Notes { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "sortKey", MessageParam = "ADM_MA_ITEMS_ENTRY_00009")]
        public decimal? SortKey { get; set; }
        [OutputText(Format = "{0:N0}")]
        [InputText(RuleName = "versionNo", MessageParam = "ADM_MA_ITEMS_ENTRY_00010")]
        public decimal? VersionNo { get; set; }
        [OutputText]
        [InputText(RuleName = "boolean", MessageParam = "ADM_MA_ITEMS_ENTRY_00011")]
        public bool? DeleteFlag { get; set; }

        [OutputText]
        public string LocaleName { get; set; }
    }
}