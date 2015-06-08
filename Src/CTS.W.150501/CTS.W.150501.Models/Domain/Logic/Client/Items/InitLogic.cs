﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.W._150501.Models.Domain.Model.Client.Items;
using CTS.Com.Domain.Helper;
using CTS.W._150501.Models.Domain.Object.Client.Main;
using CTS.W._150501.Models.Domain.Dao.Client;
using CTS.Data.APLocales.Domain.Utils;
using CTS.Data.Domain.Constants;

namespace CTS.W._150501.Models.Domain.Logic.Client.Items
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
        
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
           
            // Lấy danh sách menu
            var listItems = processDao.GetListItems(inputObject.LocaleCd,inputObject.CategoryCd);
            // Gán giá trị trả về
            getResult.ListItems = listItems;
            // Kết quả trả về
            return getResult;
        }
        #endregion
    }
}