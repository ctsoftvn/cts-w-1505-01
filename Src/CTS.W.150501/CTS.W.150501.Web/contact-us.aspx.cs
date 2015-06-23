using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.Web.Com.Domain.Controller;
using CTS.W._150501.Models.Domain.Logic.Client.ContactUs;
using CTS.Web.Com.Domain.Model;
using Resources;

namespace CTS.W._150501.Web
{
    public partial class contact_us : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = PageCom.Invoke(logic, null);

            
            ltCompanyName.Text = PageCom.GetValue<string>(response, "CompanyName"); 
            ltAdderess1.Text = PageCom.GetValue<string>(response, "Address1"); 
            ltAdderess2.Text = PageCom.GetValue<string>(response, "Address2"); 
            ltPhone.Text = PageCom.GetValue<string>(response, "Phone"); 

            ltEmail.Text = PageCom.GetValue<string>(response, "EmailAddress"); 
            ltWebsite.Text = PageCom.GetValue<string>(response, "Website"); 
            Page.Title = PageCom.GetValue<string>(response, "MetaTitle"); 
            Page.MetaKeywords = PageCom.GetValue<string>(response, "MetaKey"); 
            Page.MetaDescription = PageCom.GetValue<string>(response, "MetaDescription");
            btnSubmit.Text = Strings.CLN_BTN_SUBMIT;

        }
        protected void btnSubmit_Command(object sender, CommandEventArgs e)
        {
            var request = new BasicRequest();
            request.Add("Name", txtName.Text);
            request.Add("Phone", txtPhone.Text);
            request.Add("Email", txtEmail.Text);
            request.Add("Description", txtDescription.Text);
            var logic = new SendMailOperateLogic();
            var response = PageCom.Invoke(logic, request);
            if (response.ResultFlag)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_SUCCESS + "'); </script>");
                clearControls();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "clientscript", "<script> alert('" + Strings.CLN_ALERT_ERROR + "'); </script>");
            }

        }

        private void clearControls()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtDescription.Text = "";
        }
    }
}