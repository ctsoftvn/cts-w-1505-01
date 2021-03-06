﻿using System.Collections.Generic;
using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Items.Entry
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [InputText(RuleName = "code", MessageParam = "ADM_MA_ITEMS_00002")]
        public string ItemCd { get; set; }
        [OutputObject(IgnoreAttribute = false)]
        public LocaleModel<ItemObject> LocaleModel { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboCategories { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboDeleteFlag { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboLocales { get; set; }
        [OutputText]
        public string CboLocalesSeleted { get; set; }
    }
}
