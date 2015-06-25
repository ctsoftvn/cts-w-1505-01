using CTS.Com.Domain.Exceptions;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Constants;
using CTS.Data.IMUsers.Domain.Utils;
using CTS.W._150501.Models.Domain.Model.Admin.Users.Profile;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Users.Profile
{
    /// <summary>
    /// SaveLogic
    /// </summary>
    public class SaveLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý save.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public SaveDataModel Execute(SaveDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
            var resultObject = SaveInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(SaveDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var userCom = new UserCom();
            var msgs = DataHelper.CreateList<Message>();
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(inputObject.Password)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_USERS_PROFILE_00001"));
            }
            if (DataCheckHelper.IsNull(inputObject.NewPassword)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_USERS_PROFILE_00002"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra hợp lệ
            var userInfo = userCom.AuthInfo(DataLogics.CD_APP_CD_ADM, WebContextHelper.UserName, inputObject.Password);
            if (userInfo == null) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00020", "ADM_USERS_PROFILE_00001"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
            // Kiểm tra hợp lệ
            if (inputObject.NewPassword != inputObject.ConfirmPassword) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00013", "ADM_USERS_PROFILE_00002"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
        }

        /// <summary>
        /// Save thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SaveDataModel SaveInfo(SaveDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var saveResult = new SaveDataModel();
            var userCom = new UserCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, saveResult);
            //Tiến hành cập nhật lại mật khẩu
            userCom.UpdatePassword(WebContextHelper.UserCd, inputObject.NewPassword);
            // Thêm thông báo thành công
            saveResult.AddMessage("I_MSG_00004");
            // Kết quả trả về
            return saveResult;
        }
        #endregion
    }
}
