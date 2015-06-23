using System.Threading;
using System.Web.Services;
using CTS.Com.Domain.Helper;
using CTS.Data.Domain.Constants;
using CTS.W._150501.Models.Domain.Logic.Admin.Master.Categories.Entry;
using CTS.Web.Com.Domain.Controller;
using CTS.Web.Com.Domain.Model;

namespace CTS.W._150501.Web.ajx.adm.ma.categories
{
    public partial class entry : PageBase
    {
        [WebMethod]
        public static object InitLayout(object request)
        {
            var logic = new InitOperateLogic();
            var response = Ajax.Invoke(logic, request, DataLogics.CD_APP_CD_ADM);
            return response;
        }

        [WebMethod]
        public static object Save(object request)
        {
            var logic = new SaveOperateLogic();
            var response = Ajax.Invoke(logic, request, DataLogics.CD_APP_CD_ADM);
            return response;
        }

        [WebMethod]
        public static object GenCategoryCd(object request)
        {
            var response = new BasicResponse();
            var param = Ajax.ToRequest(request);
            if (param.IsAdd) {
                Thread.Sleep(1000);
                response.Add("CategoryCd", DataHelper.GetUniqueKey());
            }
            return response;
        }
    }
}