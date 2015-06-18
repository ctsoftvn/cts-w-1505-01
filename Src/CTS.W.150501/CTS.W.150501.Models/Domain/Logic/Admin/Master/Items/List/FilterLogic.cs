using CTS.Com.Domain.Helper;
using CTS.Com.Domain.Model;
using CTS.W._150501.Models.Domain.Dao.Admin;
using CTS.W._150501.Models.Domain.Model.Admin.Master.Items.List;
using CTS.W._150501.Models.Domain.Object.Admin.Master.Items;

namespace CTS.W._150501.Models.Domain.Logic.Admin.Master.Items.List
{
    /// <summary>
    /// FilterLogic
    /// </summary>
    public class FilterLogic
    {
        #region Execute Method
        /// <summary>
        /// Xử lý filter.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        public FilterDataModel Execute(FilterDataModel inputObject)
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
        private void Check(FilterDataModel inputObject)
        {
        }

        /// <summary>
        /// Lấy thông tin.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var getResult = new FilterDataModel();
            // Map dữ liệu
            DataHelper.CopyObject(inputObject, getResult);
            // Lấy đối tượng pager
            var pagerData = GetPagerData(inputObject);
            // Gán giá trị trả về
            getResult.ListData = pagerData.ListData;
            getResult.Total = pagerData.Total;
            // Kết quả trả về
            return getResult;
        }

        /// <summary>
        /// Lấy đối tượng pager
        /// </summary>
        private PagerInfoModel<ItemObject> GetPagerData(FilterDataModel inputObject)
        {
            // Khởi tạo biến cục bộ
            var pagerResult = new PagerInfoModel<ItemObject>();
            var processDao = new MasterItemsDao();
            // Lấy đối tượng pager
            var pagerData = processDao.GetPagerData(inputObject);
            // Gán giá trị trả về
            pagerResult.ListData = pagerData.ListData;
            pagerResult.Total = pagerData.Total;
            // Kết quả trả về
            return pagerResult;
        }
        #endregion
    }
}