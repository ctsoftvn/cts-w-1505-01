using System.Collections.Generic;
using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Items.List
{
    /// <summary>
    /// SaveBatchDataModel
    /// </summary>
    public class SaveBatchDataModel : BasicInfoModel
    {
        [InputList(IgnoreAttribute = false)]
        public IList<ItemObject> ListData { get; set; }
    }
}
