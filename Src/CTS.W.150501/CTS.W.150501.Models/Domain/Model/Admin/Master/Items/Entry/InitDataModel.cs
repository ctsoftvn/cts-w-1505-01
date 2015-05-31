using System.Collections.Generic;
using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Items.Entry
{
    public class InitDataModel : BasicInfoModel
    {
        [InputText(RuleName = "code20", MessageParam = "ADM_MA_ITEMS_00002")]
        public string ItemCd { get; set; }
        [OutputObject(IgnoreAttribute = false)]
        public LocaleModel<ItemObject> LocaleModel { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> ListCategories { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> ListDeleteFlag { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> ListLocales { get; set; }
        [OutputText]
        public string SeletedValueLocales { get; set; }
    }
}
