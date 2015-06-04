using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Com.Domain.Controller;
using CTS.W._150501.Models.Domain.Logic.Client.Main;
using CTS.Com.Domain.Model;

namespace CTS.W._150501.Web
{
    public partial class index : MasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);
            var listMenu = (IList<object>)response["ListMenu"];
            rptCategories.DataSource = listMenu;
            rptCategories.DataBind();

            var listLocales = (IList<object>)response["ListLocales"];
            rptLanguages.DataSource = listLocales;
            rptLanguages.DataBind();
        }
    }
}