using System.Collections.Generic;
using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Model;

namespace CTS.W._150501.Models.Domain.Model.Admin.Main
{
    /// <summary>
    /// InitDataModel
    /// </summary>
    public class InitDataModel : BasicInfoModel
    {
        [OutputObject(IgnoreAttribute = true)]
        public UserContext UserContext { get; set; }
        [OutputList(IgnoreAttribute = true)]
        public IList<MenuObject> ListNavBar { get; set; }
    }
}
