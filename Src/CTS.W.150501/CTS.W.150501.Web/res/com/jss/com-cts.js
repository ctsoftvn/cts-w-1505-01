// -----------------------------------------------------------------
// Common AngularJS Plugin
// -----------------------------------------------------------------
// Yêu cậu khi import plugin:
//   + jQuery Plugin
//   + CTS Helper Plugin
// -----------------------------------------------------------------
'use strict';
// -----------------------------------------------------------------
// Định nghĩa phím tắc cho chức năng trên màn hình
// -----------------------------------------------------------------
var functionKeys = cts.helper.PageHelper.KEYS;
// -----------------------------------------------------------------
// Định nghĩa BrowserHelper
// -----------------------------------------------------------------
var $browserHelper = cts.helper.BrowserHelper;
// -----------------------------------------------------------------
// Định nghĩa DataHelper
// -----------------------------------------------------------------
var $dataHelper = cts.helper.DataHelper;
// -----------------------------------------------------------------
// Định nghĩa CheckHelper
// -----------------------------------------------------------------
var $checkHelper = cts.helper.CheckHelper;
// -----------------------------------------------------------------
// -----------------------------------------------------------------
// Định nghĩa ResourceHelper
// -----------------------------------------------------------------
var $resourceHelper = cts.helper.ResourceHelper;
// -----------------------------------------------------------------
// Định nghĩa PageHelper
// -----------------------------------------------------------------
var $pageHelper = cts.helper.PageHelper;
// -----------------------------------------------------------------
// Định nghĩa PageHelper
// -----------------------------------------------------------------
var $gridHelper = cts.helper.GridHelper;
// -----------------------------------------------------------------
// Định nghĩa DialogHelper
// -----------------------------------------------------------------
var $dialogHelper = cts.helper.DialogHelper;
/** 
* Lấy chuỗi resource name
* @param s: chuỗi id
* @returns chuỗi resource name
*/
var $nm = function (s) {
    return cts.helper.ResourceHelper.getName(s);
};
/** 
* Lấy chuỗi resource message
* @param s: chuỗi id
* @returns chuỗi resource message
*/
var $ms = function (s) {
    return cts.helper.ResourceHelper.getMessage(s);
};
/** 
* Xử lý chính
* @param obj: đối tượng xử lý
*/
var $pc = function (obj) {
    cts.helper.PageHelper.process(obj);
};
/** 
* Chuyển hướng đến địa chỉ trang cụ thể với tham số
* @param id: id của trang
* @param url: địa chỉ trang
* @param param: tham số
*/
var $rd = function (id, url, param) {
    cts.helper.VariableHelper.setValue(id, id, param);
    window.location = url
};
/** 
* Lấy đối tượng tham số của trang
* @param id: id của trang
* @returns đối tượng tham số
*/
var $pr = function (id) {
    return cts.helper.VariableHelper.getValue(id, id);
};
/** 
* Lấy giá trị của biến
* @param id: id của trang
* @param name: tên biến
* @returns giá trị
*/
var $gv = function (id, name) {
    return cts.helper.VariableHelper.getValue(id, name);
};
/** 
* Gán giá trị vào biến
* @param id: id của trang
* @param name: tên biến
* @param value: giá trị gán
*/
var $sv = function (id, name, value) {
    return cts.helper.VariableHelper.setValue(id, name, value);
};
/** 
* Áp dụng trình tự di chuyển tab
*/
var $ti = function (elm) {
    cts.helper.PageHelper.updateTabIndex();
    cts.helper.PageHelper.applyMoveTab();
    if (elm) {
        $el(elm).focus();
    }
};
/** 
* Lấy element theo tên
* @param name: mã/tên element
* @returns element
*/
var $el = function (elm) {
    return $('#' + elm) || $('[name=' + elm + ']');
};