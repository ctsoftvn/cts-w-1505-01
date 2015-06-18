using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Model.Client.ItemDetail;
using CTS.Web.Com.Domain.Logic;
using CTS.Web.Com.Domain.Model;

namespace CTS.W._150501.Models.Domain.Logic.Client.ItemDetail
{
    /// <summary>
    /// SendMailOperateLogic
    /// </summary>
    public class SendMailOperateLogic : IOperateLogic
    {
        #region Invoke Method
        public BasicResponse Invoke(BasicRequest request)
        {
            // Khởi tạo biến cục bộ
            var logic = new SendMailLogic();
            // Convert đối tượng request
            var inputObject = MapHelper.Convert<SendMailDataModel>(request);
            // Thực thi xử lý logic
            var resultObject = logic.Execute(inputObject);
            // Convert đối tượng response
            var response = MapHelper.Convert<BasicResponse>(resultObject);
            // Kết quả trả về
            return response;
        }
        #endregion
    }
}
