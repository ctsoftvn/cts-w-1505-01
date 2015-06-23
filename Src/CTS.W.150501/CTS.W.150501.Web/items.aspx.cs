using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Com.Domain.Controller;
using CTS.W._150501.Models.Domain.Logic.Client.Items;
using CTS.Web.Com.Domain.Model;
using CTS.Web.Com.Domain.Helper;
using System.Web.Services;

namespace CTS.W._150501.Web
{
    public partial class items : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = new BasicRequest();
            request.Add("LinkName", Request["name"]);
            request.Add("Offset", 0);
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, request);
            if (response.ResultFlag)
            {
                var listItems = PageCom.GetValue<IList<object>>(response, "ListData");
                rptItems.DataSource = listItems;
                rptItems.DataBind();
                hdTotal.Value = PageCom.GetValue<string>(response, "Total");
                hdLimit.Value = PageCom.GetValue<string>(response, "LimitPager");

                Page.Title = PageCom.GetValue<string>(response, "MetaTitle");
                Page.MetaKeywords = PageCom.GetValue<string>(response, "MetaKey");
                Page.MetaDescription = PageCom.GetValue<string>(response, "MetaDescription");
                HdcatCd.Value = PageCom.GetValue<string>(response, "CategoryCd");
            }
            else
            {
                Response.Redirect("/" + WebContextHelper.LocaleCd + "/trang-chu");
            }
        }

        [WebMethod]
        public static object Filter(object request)
        {
            var logic = new FilterOperateLogic();
            var response = Ajax.Invoke(logic, request);
            return response;
        }

    }
}