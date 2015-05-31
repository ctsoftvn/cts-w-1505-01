using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Items.Entry
{
    public class SaveDataModel : BasicInfoModel
    {
        [InputObject(IgnoreAttribute = false)]
        public LocaleModel<ItemObject> LocaleModel { get; set; }
    }
}
