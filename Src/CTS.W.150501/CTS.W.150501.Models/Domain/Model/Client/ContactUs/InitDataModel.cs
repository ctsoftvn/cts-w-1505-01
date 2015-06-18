using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.Com.Domain.Model;
using CTS.Com.Domain.Attr;
using CTS.W._150501.Models.Domain.Object.Client.Main;

namespace CTS.W._150501.Models.Domain.Model.Client.ContactUs
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [InputText]
        public string InfoCd { get; set; }
        [OutputText]
        public string CompanyName { get; set; }
        [OutputText]
        public string EmailAddress { get; set; }
        [OutputText]
        public string EmailPassword { get; set; }
        [OutputText]
        public string Address1 { get; set; }
        [OutputText]
        public string Address2 { get; set; }
        [OutputText]
        public string Phone { get; set; }
        [OutputText]
        public string Website { get; set; }
        [OutputText]
        public string MetaKey { get; set; }
        [OutputText]
        public string MetaTitle { get; set; }
        [OutputText]
        public string MetaDescription { get; set; }
    }
}
