using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Client.Main;

namespace CTS.W._150501.Models.Domain.Model.Client.Items
{
    /// <summary>
    /// FilterDataModel
    /// </summary>
    public class FilterDataModel : PagerInfoModel<ItemObject>
    {
        [InputText]
        public string CategoryCd { get; set; }

    }
}
