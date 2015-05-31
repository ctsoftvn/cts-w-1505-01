using CTS.Com.Domain.Attr;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Model.Admin.Users.Profile
{
    /// <summary>
    /// SaveDataModel
    /// </summary>
    public class SaveDataModel : BasicInfoModel
    {
        [InputText(RuleName = "password", MessageParam = "ADM_USERS_PROFILE_00001")]
        public string Password { get; set; }
        [InputText(RuleName = "password", MessageParam = "ADM_USERS_PROFILE_00002")]
        public string NewPassword { get; set; }
        [InputText]
        public string ConfirmPassword { get; set; }
    }
}
