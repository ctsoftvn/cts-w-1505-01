using CTS.Com.Domain.Exceptions;
using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.Data.Domain.Constants;
using CTS.Data.IMUsers.Domain.Utils;
using CTS.W._150501.Models.Domain.Common.Constants;
using CTS.W._150501.Models.Domain.Model.Admin.Login;
using CTS.Web.Com.Domain.Utils;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Login
{
    /// <summary>
    /// AuthLogic
    /// </summary>
    public class AuthLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý auth.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public AuthDataModel Execute(AuthDataModel inputObject)
        {
            // Kiểm tra thông tin
            Check(inputObject);
            // Lấy thông tin
            var resultObject = GetInfo(inputObject);
            // Kết quả trả về
            return resultObject;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Kiểm tra thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(AuthDataModel inputObject)
        {// Khởi tạo biến cục bộ
            var msgs = DataHelper.CreateList<Message>();
            // Kiểm tra bắt buộc
            if (DataCheckHelper.IsNull(inputObject.UserName)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_LOGIN_00001"));
            }
            if (DataCheckHelper.IsNull(inputObject.Password)) {
                msgs.Add(MessageHelper.GetMessage("E_MSG_00001", "ADM_LOGIN_00002"));
            }
            // Kiểm tra danh sách lỗi
            if (!DataCheckHelper.IsNull(msgs)) {
                throw new ExecuteException(msgs);
            }
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private AuthDataModel GetInfo(AuthDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new AuthDataModel();
            var userCom = new UserCom();
            var pageCom = new PageCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy thông tin xác thực
            var userInfo = userCom.AuthInfo(DataLogics.CD_APP_CD_ADM, inputObject.UserName, inputObject.Password);
            // Trường hợp không tồn tại thông tin xác thực
            if (userInfo == null || userInfo.IsEmpty) {
                throw new ExecuteException("E_MSG_00014");
            }
            // Xác thực quyền hạn trang quản trị
            userCom.AuthRole(userInfo.UserCd, W150501Logics.CD_ROLE_CD_ADM_MAIN);
            // Tạo user context
            var context = new UserContext() {
                UserCd = userInfo.UserCd,
                UserName = userInfo.UserName,
                LocaleCd = userInfo.LocaleCd,
                AppCd = DataLogics.CD_APP_CD_ADM
            };
            // Cập nhật user context
            pageCom.LoadUserContext(context);
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
