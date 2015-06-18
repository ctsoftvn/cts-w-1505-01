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
        [InputText]
        public string LinkName { get; set; }
        [OutputObject(IgnoreAttribute = false)]
        public ItemObject Item { get; set; }
        [OutputList(IgnoreAttribute = false)]
        public IList<ItemObject> ListRelations { get; set; }
        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }

    }
}
