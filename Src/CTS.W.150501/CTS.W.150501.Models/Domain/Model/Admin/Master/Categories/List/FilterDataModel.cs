using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Categories;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Categories.List
{
    /// <summary>
    /// FilterDataModel
    /// </summary>
    public class FilterDataModel : PagerInfoModel<CategoryObject>
    {
        [InputText(RuleName = "name", MessageParam = "ADM_MA_CATEGORIES_00003")]
        public string CategoryName { get; set; }
        [InputText(RuleName = "linkName", MessageParam = "ADM_MA_Category_00005")]
        public string LinkName { get; set; }
        [InputText(RuleName = "boolean", MessageParam = "ADM_MA_Category_00011")]
        public bool? DeleteFlag { get; set; }
    }
}
