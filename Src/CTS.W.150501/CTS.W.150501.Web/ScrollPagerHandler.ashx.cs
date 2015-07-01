using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Logic.Client.Items;
using CTS.Web.Com.Domain.Helper;
using CTS.Web.Com.Domain.Model;
using CTS.Web.Com.Domain.Utils;

namespace CTS.W._150501.Web
{
    /// <summary>
    /// Summary description for ScrollPagerHandler
    /// </summary>
    public class ScrollPagerHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "html";
            int tzpage = Convert.ToInt32(context.Request.QueryString["p"]);
            int limit = Convert.ToInt32(context.Request.QueryString["l"]);
            string categoryCd = context.Request.QueryString["c"];

            var offset = (tzpage - 1) * limit;

            var pageCom = new PageCom();
            var request = new BasicRequest();
            request.Add("CategoryCd", categoryCd);
            request.Add("Offset", offset);
            request.Add("Limit", limit);
            var logic = new FilterOperateLogic();
            var response = pageCom.Invoke(logic, request);
            if (response.ResultFlag) {
                var listItems = pageCom.GetValue<IList<object>>(response, "ListData");
                context.Response.Write(GenerateHTML(listItems));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        private string GenerateHTML(IList<object> lstItems)
        {
            var pageCom = new PageCom();
            StringBuilder strHTML = new StringBuilder();

            for (int i = 0; i < lstItems.Count; i++) {
                var obj = (HashMap)lstItems[i];
                //Begin
                strHTML.AppendLine(@"<li class='element tz_item'>");
                strHTML.AppendLine("<div class='inner'>");
                var itemName = pageCom.GetValue<string>(obj, "ItemName");
                var linkName = pageCom.GetValue<string>(obj, "LinkName");
                strHTML.AppendLine("<a href='/" + WebContextHelper.LocaleCd + "/dich-vu/chi-tiet/" + linkName + "'" + "title='" + itemName + "'>");
                var itemImage = pageCom.GetValue<string>(obj, "ItemImage");
                strHTML.AppendLine("<img src='/ImageResize.ashx?w=420&h=320&bgcolor=FFF&path=" + itemImage + "'/>");
                strHTML.AppendLine("</a>");
                strHTML.AppendLine("</div>");
                strHTML.AppendLine("</li>");

            }
            return strHTML.ToString();
        }
    }
}