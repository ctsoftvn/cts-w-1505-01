﻿using System.Web.Services;
using CTS.Data.Domain.Constants;
using CTS.W._150501.Models.Domain.Logic.Admin.Master.Items.Entry;
using CTS.Web.Com.Domain.Controller;

namespace CTS.W._150501.Web.ajx.adm.ma.items
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
    }
}