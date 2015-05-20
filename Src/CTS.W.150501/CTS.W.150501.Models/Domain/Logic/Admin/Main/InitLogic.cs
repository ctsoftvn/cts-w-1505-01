using System.Collections.Generic;
using CTS.Com.Domain.Helper;
using CTS.Data.APMenuItems.Domain.Utils;
using CTS.Data.Domain.Constants;
using CTS.Data.Domain.Model;
using CTS.W._150501.Models.Domain.Model.Admin.Main;
using CTS.Web.Com.Domain.Helper;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Main
{
    /// <summary>
    /// InitLogic
    /// </summary>
    public class InitLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý init.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public InitDataModel Execute(InitDataModel inputObject)
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
        private void Check(InitDataModel inputObject)
        {
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new InitDataModel();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy user context
            var userContext = WebContextHelper.UserContext;
            // Lấy danh sách navbar
            var listNavBar = GetListNavBar();
            // Gán giá trị trả về
            getResult.UserContext = userContext;
            getResult.ListNavBar = listNavBar;
            // Kết quả trả về
            return getResult;
        }

        /// <summary>
        /// Lấy danh sách navbar
        /// </summary>
        private IList<MenuObject> GetListNavBar()
        {
            // Khởi tạo biến cục bộ
            var menuCom = new MenuCom();
            // Lấy danh sách navbar
            var listNavBar = menuCom.GetListWithArgs(
                WebContextHelper.LocaleCd, DataLogics.CD_APP_CD_ADM, false);
            // Kết quả trả về
            return listNavBar;
        }
        #endregion
    }
}
