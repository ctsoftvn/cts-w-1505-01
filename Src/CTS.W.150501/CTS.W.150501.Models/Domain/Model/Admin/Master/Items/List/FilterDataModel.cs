using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Items.List
{
    /// <summary>
    /// FilterDataModel
    /// </summary>
    public class FilterDataModel : PagerInfoModel<ItemObject>
    {
        [InputText(RuleName = "code", MessageParam = "ADM_MA_ITEMS_00002")]
        public string ItemCd { get; set; }
        [InputText(RuleName = "name", MessageParam = "ADM_MA_ITEMS_00003")]
        public string ItemName { get; set; }
        [InputText(RuleName = "linkName", MessageParam = "ADM_MA_ITEMS_00005")]
        public string LinkName { get; set; }
        [InputText(RuleName = "code", MessageParam = "ADM_MA_ITEMS_00006")]
        public string CategoryCd { get; set; }
        [InputText(RuleName = "boolean", MessageParam = "ADM_MA_ITEMS_00011")]
        public bool? DeleteFlag { get; set; }
    }
}
