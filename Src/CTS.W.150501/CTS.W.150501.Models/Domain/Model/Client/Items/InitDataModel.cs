using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Com.Domain.Model;
using CTS.Com.Domain.Attr;
using CTS.W._150501.Models.Domain.Object.Client.Main;

namespace CTS.W._150501.Models.Domain.Model.Client.Items
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : PagerInfoModel<ItemObject>
    {
        [InputText]
        public string LinkName { get; set; }
        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }
        [OutputText]
        public string CategoryCd { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? LimitPager { get; set; }

    }
}
