using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Com.Domain.Controller;
using CTS.W._150501.Models.Domain.Logic.Client.Main;
using CTS.Com.Domain.Model;
using CTS.Web.Com.Domain.Helper;
using Resources;

namespace CTS.W._150501.Web
{
    public partial class index : MasterPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);
            var listMenu = PageCom.GetValue<IList<object>>(response, "ListMenu");
            rptCategories.DataSource = listMenu;
            rptCategories.DataBind();

            var listLocales = PageCom.GetValue<IList<object>>(response, "CboLocales"); 
            rptLanguages.DataSource = listLocales;
            rptLanguages.DataBind();

            var companyName = PageCom.GetValue<string>(response, "CompanyName"); 
            var copyright = string.Format(Strings.CLN_MASTER_COPYRIGHT, companyName);
            ltCopyright.Text = copyright;

            lkHome.NavigateUrl = Convert.ToString(Strings.CLN_MASTER_HOMEPAGE_LINK);
            lkHome.ToolTip = PageCom.GetValue<string>(response, "CompanyName"); 

            lkFhome.NavigateUrl = Convert.ToString(Strings.CLN_MASTER_HOMEPAGE_LINK);
            lkFaboutUs.NavigateUrl = Convert.ToString(Strings.CLN_MASTER_ABOUTUS_LINK);
            lkFcontactUs.NavigateUrl = Convert.ToString(Strings.CLN_MASTER_CONTACTUS_LINK);

            ltCompanyName.Text = PageCom.GetValue<string>(response, "CompanyName"); 
            ltSlogan.Text = PageCom.GetValue<string>(response, "Slogan"); 
            ltCopyright.Text = PageCom.GetValue<string>(response, "Copyright"); 
            ltAdderess1.Text = PageCom.GetValue<string>(response, "Address1"); 
            ltAdderess2.Text = PageCom.GetValue<string>(response, "Address2"); 
            ltHotline.Text = PageCom.GetValue<string>(response, "Hotline"); 

            lkTwitter.NavigateUrl = PageCom.GetValue<string>(response, "TwitterUrl"); 
            lkGoogle.NavigateUrl = PageCom.GetValue<string>(response, "GoogleUrl"); 
            lkfacebook.NavigateUrl = PageCom.GetValue<string>(response, "FacebookUrl"); 

            imgAdvertising.ImageUrl = PageCom.GetValue<string>(response, "AdvertisingFileCd"); 
            hplAdvertising.NavigateUrl = PageCom.GetValue<string>(response, "AdvertisingFileUrl"); 

            lkMhome.NavigateUrl = Convert.ToString(Strings.CLN_MASTER_HOMEPAGE_LINK);
        }
        protected void lbtnLanguage_Command(object sender, CommandEventArgs e)
        {
            var strRawURL = Request.RawUrl;
            var newLang = string.Format("/{0}/", Convert.ToString(e.CommandArgument));
            var oldLang = string.Format("/{0}/", WebContextHelper.LocaleCd);

            if (newLang != oldLang)
            {
                if (strRawURL.IndexOf(oldLang) < 0)
                {
                    strRawURL = newLang + strRawURL.TrimStart('/');
                }
                else
                {
                    strRawURL = strRawURL.Replace(oldLang, newLang);
                }
            }
            if (strRawURL.TrimEnd('/').Length == 0)
            {
                strRawURL = string.Format("/{0}/trang-chu", oldLang);
            }

            strRawURL = strRawURL.Replace("/items.aspx", "/trang-chu");
            strRawURL = strRawURL.Replace("/about-us.aspx", "/gioi-thieu");
            strRawURL = strRawURL.Replace("/contact-us.aspx", "/lien-he");

            Response.Redirect(strRawURL, true);
        }
    }
}