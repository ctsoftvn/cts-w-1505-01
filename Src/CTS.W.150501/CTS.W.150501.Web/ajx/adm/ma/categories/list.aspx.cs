using System.Web.Services;
using CTS.Data.Domain.Constants;
using CTS.W._150501.Models.Domain.Logic.Admin.Master.Categories.List;
using CTS.Web.Com.Domain.Controller;

namespace CTS.W._150501.Web.ajx.adm.ma.categories
{
    public partial class list : PageBase
    {
        [WebMethod]
        public static object InitLayout(object request)
        {
            var logic = new InitOperateLogic();
            var response = Ajax.Invoke(logic, request, DataLogics.CD_APP_CD_ADM);
            return response;
        }

        [WebMethod]
        public static object Filter(object request)
        {
            var logic = new FilterOperateLogic();
            var response = Ajax.Invoke(logic, request, DataLogics.CD_APP_CD_ADM);
            return response;
        }

        [WebMethod]
        public static object SaveBatch(object request)
        {
            var logic = new SaveBatchOperateLogic();
            var response = Ajax.Invoke(logic, request, DataLogics.CD_APP_CD_ADM);
            return response;
        }
    }
}