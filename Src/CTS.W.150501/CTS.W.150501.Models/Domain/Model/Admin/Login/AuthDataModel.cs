using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Model.Admin.Login
{
    /// <summary>
    /// AuthDataModel
    /// </summary>
    public class AuthDataModel : BasicInfoModel
    {
        [InputText(RuleName = "userName", MessageParam = "ADM_LOGIN_00001", Required = true)]
        public string UserName { get; set; }
        [InputText(RuleName = "password", MessageParam = "ADM_LOGIN_00002", Required = true)]
        public string Password { get; set; }
    }
}
