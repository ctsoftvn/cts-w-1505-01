using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.ContactUs;
using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Web.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.Data.APStorageFiles.Domain.Utils;
using CTS.Com.Domain.Constants;
using CTS.Com.Domain.Exceptions;
using CTS.Com.Domain.Model;
using CTS.Data.MACompanyInfos.Domain.Utils;
using CTS.Data.APSEOInfos.Domain.Utils;
using CTS.W._150501.Models.Resources.Strings;

namespace CTS.W._150501.Models.Domain.Logic.Client.ContactUs
{
    /// <summary>
    /// InitLogic
    /// </summary>
    public class SendMailLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý init.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SendMailDataModel Execute(SendMailDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
            var resultObject = SendInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(SendMailDataModel inputObject)
        {

        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SendMailDataModel SendInfo(SendMailDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new SendMailDataModel();
            var companyCom = new CompanyCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin dữ liệu
            var fileTemplate = FileHelper.ToString(PageHelper.MapPath("/stg/tmpl/email/contact-us.html"));
            var emailAddress = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_EMAIL_ADDRESS, false);
            var hostEmailAddress = companyCom.GetString(WebContextHelper.LocaleCd, W150501Logics.CD_INFO_CD_EMAIL_HOST, false);
            var subject = Names.CLN_CONTACT_00001;
            var body = new StringBuilder(fileTemplate);
            body.Replace("{Name}", inputObject.Name);
            body.Replace("{Phone}", inputObject.Phone);
            body.Replace("{Email}", inputObject.Email);
            body.Replace("{Description}", inputObject.Description);
            // Tiến hành send mail
            MailHelper.SendMail(inputObject.Email, emailAddress, subject, body.ToString(), hostEmailAddress);
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
