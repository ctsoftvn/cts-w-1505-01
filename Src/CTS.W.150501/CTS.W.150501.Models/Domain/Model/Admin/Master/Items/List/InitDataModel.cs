using System.Collections.Generic;
using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Model.Admin.Master.Items.List
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboCategories { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboLocales { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboDeleteFlag { get; set; }
        [OutputText]
        public string CboLocalesSeleted { get; set; }
        [OutputText]
        public string CboCategoriesSeleted { get; set; }
        [OutputText]
        public bool? CboDeleteFlagSeleted { get; set; }

        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboGrdCategories { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboGrdDeleteFlag { get; set; }

        [OutputText]
        public string BasicLocale { get; set; }
        [OutputText(Format = "{0:N0}")]
        public decimal? Limit { get; set; }
    }
}
