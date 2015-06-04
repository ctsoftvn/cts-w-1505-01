using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.Main;
using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;

namespace CTS.W._150501.Models.Domain.Logic.Client.Main
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
            var processDao = new MainDao();
            var localeCom = new LocaleCom();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy danh sách ngôn ngữ
            var listLocales = localeCom.GetDiv(DataLogics.CD_APP_CD_CLN, null, false, false);
            // Lấy danh sách menu
            var listMenu = processDao.GetListCategories(inputObject.LocaleCd);
            // Gán giá trị trả về
            getResult.ListLocales = listLocales;
            getResult.ListMenu = listMenu;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}
