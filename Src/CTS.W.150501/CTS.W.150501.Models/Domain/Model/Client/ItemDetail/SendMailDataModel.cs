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
    public class SendMailDataModel : BasicInfoModel
    {
        [InputText]
        public string Name { get; set; }
        [InputText]
        public string Phone { get; set; }
        [InputText(RuleName="email", MessageParam="CLN.ITEMDETAIL.00001")]
        public string Email { get; set; }
        [InputText]
        public string Description { get; set; }
        

    }
}
