using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Com.Domain.Model;
using CTS.Com.Domain.Attr;
using CTS.W._150501.Models.Domain.Object.Client.Main;

namespace CTS.W._150501.Models.Domain.Model.Client.Main
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [OutputList(IgnoreAttribute = false)]
        public IList<CategoryObject> ListMenu { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<ComboItem> CboLocales { get; set; }
        [OutputText]
        public string CboLocalesSeleted { get; set; }

        
        [OutputText]
        public string CompanyName { get; set; }
        [OutputText]
        public string Slogan { get; set; }
        [OutputText]
        public string AdvertisingFileCd { get; set; }
        [OutputText]
        public string AdvertisingFileUrl { get; set; }
        [OutputText]
        public string Copyright{ get; set; }
        [OutputText]
        public string Address1 { get; set; }
        [OutputText]
        public string Address2 { get; set; }
        [OutputText]
        public string Hotline { get; set; }
        [OutputText]
        public string TwitterUrl { get; set; }
        [OutputText]
        public string GoogleUrl { get; set; }
        [OutputText]
        public string FacebookUrl { get; set; }
        [OutputText]
        public string ScriptHeader { get; set; }
        [OutputText]
        public string ScriptFooter { get; set; }
        

    }
}
