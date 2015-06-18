using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Com.Domain.Controller;
using CTS.W._150501.Models.Domain.Logic.Client.AboutUs;

namespace CTS.W._150501.Web
{
    public partial class about_us : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);

            ltDescription.Text = PageCom.GetValue<string>(response, "AboutUsDescription");
            Page.Title = PageCom.GetValue<string>(response, "MetaTitle"); 
            Page.MetaKeywords = PageCom.GetValue<string>(response, "MetaKey"); 
            Page.MetaDescription = PageCom.GetValue<string>(response, "MetaDescription"); 
        }
    }
}