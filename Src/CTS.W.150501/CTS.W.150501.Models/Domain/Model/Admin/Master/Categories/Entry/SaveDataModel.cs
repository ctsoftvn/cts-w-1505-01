using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Categories;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Categories.Entry
{
    public class SaveDataModel : BasicInfoModel
    {
        [InputObject(IgnoreAttribute = false)]
        public LocaleModel<CategoryObject> LocaleModel { get; set; }
    }
}