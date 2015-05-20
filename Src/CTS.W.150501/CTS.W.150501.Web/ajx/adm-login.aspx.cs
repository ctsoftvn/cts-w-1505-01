using System.Web.Services;
using CTS.Data.Domain.Constants;
using CTS.W._150501.Models.Domain.Logic.Admin.Login;
using CTS.Web.Com.Domain.Controller;

namespace CTS.W._150501.Web.ajx
{
    public partial class adm_login : PageBase
    {
        [WebMethod]
        public static object InitLayout(object request)
        {
            var logic = new InitOperateLogic();
            var response = Ajax.Invoke(logic, request, DataLogics.CD_APP_CD_ADM);
            return response;
        }

        [WebMethod]
        public static object Auth(object request)
        {
            var logic = new AuthOperateLogic();
            var response = Ajax.Invoke(logic, request);
            return response;
        }
    }
}