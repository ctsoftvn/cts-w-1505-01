using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Com.Domain.Model;
using CTS.Com.Domain.Attr;
using CTS.W._150501.Models.Domain.Object.Client.Main;

namespace CTS.W._150501.Models.Domain.Model.Client.ItemDetail
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = false)]
        public ItemObject Item { get; set; }
        public IList<ItemObject> ListRelations { get; set; }

    }
}
