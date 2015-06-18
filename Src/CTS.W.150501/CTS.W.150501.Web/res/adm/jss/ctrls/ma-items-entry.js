// MAItemsEntryCtrl
ctrls.controller('MAItemsEntryCtrl', ['$scope', '$state', '$stateParams', '$window', function ($scope, $state, $stateParams, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.style = {};
    $scope.variable = {};
    $scope.objEntry = {};
    $scope.objLocale = {};
    $scope.edtNotes = {};
    // Gán giá trị init
    $scope.data.HasAuth = false;
    $scope.variable.ShowLinkBack = $state.is('master_items_list_entry');
    $scope.variable.BasicInfo = $dataHelper.toBasicInfo($stateParams);
    $scope.objEntry.tblResultOptions = $gridHelper.optBase({ width: 1800 });
    $scope.edtNotes.options = $pageHelper.EDT_OPT_DEF;
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            url: '/ajx/adm/ma/items/entry.aspx/InitLayout',
            data: {
                Status: $scope.variable.BasicInfo.Status,
                CallType: $scope.variable.BasicInfo.CallType,
                ItemCd: $stateParams.ItemCd
            },
            success: function (data) {
                if (data.HasAuth === false) {
                    $window.open('/adm/login.html', '_self');
                } else {
                    // Ẩn/Hiện cửa sổ chính
                    $scope.$parent.showViewMain(true);
                    // Gán dữ liệu xử lý
                    $scope.data = data;
                    $scope.objEntry.DataInfo = data.LocaleModel.DataInfo;
                    $scope.objEntry.ListLocale = data.LocaleModel.ListLocale;
                    // Trường hợp kết quả trả về không phải mảng
                    if (!$.isArray($scope.objEntry.ListLocale)) {
                        $scope.objEntry.ListLocale = [];
                    }
                    // Xử lý select thông tin dòng đầu tiên
                    $scope.selectRow(0);
                    // Xử lý focus
                    if ($scope.variable.BasicInfo.IsAdd) {
                        $ti('txtItemCd');
                    } else {
                        $ti('txtItemName');
                    }
                }
            }
        });
    };
    // Xử lý save
    $scope.save = function () {
        $pc({
            url: '/ajx/adm/ma/items/entry.aspx/Save',
            data: {
                Status: $scope.variable.BasicInfo.Status,
                CallType: $scope.variable.BasicInfo.CallType,
                LocaleModel: {
                    DataInfo: $scope.objEntry.DataInfo,
                    ListLocale: $scope.objEntry.ListLocale
                }
            },
            success: function (data) {
                if ($scope.variable.BasicInfo.IsEdit) {
                    $scope.back();
                } else {
                    var fnYes = function () {
                        $scope.init();
                    };
                    var fnNo = function () {
                        $scope.back();
                    };
                    $dialogHelper.showDialogConfirm($ms('I.MSG.00003'), fnYes, fnNo);
                }
            }
        });
    };
    // Xử lý back
    $scope.back = function () {
        $pc(function () {
            $state.go('master_items_list');
        });
    };
    // Xử lý tải lên hình ảnh
    $scope.uploadImage = function (obj) {
        $pc(function () {
            var modalInstance = $dialogHelper.showDialogUpload({
                LocaleCd: obj.LocaleCd,
                FileCd: obj.FileCd,
                HasGen: obj.HasGen,
                FileGroupCd: 'stg.ma.items.file-cd'
            });
            // Lấy kết quả xử lý
            modalInstance.result.then(function (result) {
                obj.FileCd = result.data;
                obj.HasGen = result.hasGen;
            });
        });
    };
    // Xử lý cố định dòng
    $scope.fixRow = function () {
        $pc(function () {
            // Khởi tạo biến cục bộ
            var obj = $scope.objLocale;
            // Cập nhật lại số dòng
            obj.RowNo = $gridHelper.getRowNo(obj.RowNo, $scope.objEntry.ListLocale);
            // Lấy chỉ số dòng trong mảng
            var rowIdx = $dataHelper.getRowIndex(obj.RowNo, $scope.objEntry.ListLocale, 'RowNo');
            if (rowIdx === -1) {
                // Kiểm tra duy nhất
                var isExist = $checkHelper.isExistData(obj.LocaleCd, $scope.objEntry.ListLocale, 'LocaleCd');
                if ($scope.data.BasicLocale === obj.LocaleCd || isExist) {
                    $dialogHelper.showDialogError($resourceHelper.getMessage('E.MSG.00004', 'ADM.MA.ITEMS.ENTRY.LocaleCd'));
                    return;
                }
                // Thêm dữ liệu vào danh sách
                $scope.objEntry.ListLocale.push(obj);
                // Clear thông tin dòng
                $scope.clearRow();
            } else {
                // Kiểm tra tồn tại
                if ($scope.objEntry.ListLocale[rowIdx].LocaleCd !== obj.LocaleCd) {
                    $dialogHelper.showDialogError($resourceHelper.getMessage('E.MSG.00006', 'ADM.MA.ITEMS.ENTRY.LocaleCd'));
                    return;
                }
                // Cập nhật dữ liệu vào danh sách
                $scope.objEntry.ListLocale[rowIdx] = obj;
                // Xử lý select thông tin dòng kế tiếp
                $scope.selectRow(parseInt(rowIdx) + 1);
            }
        });
    };
    // Xử lý clear thông tin dòng
    $scope.clearRow = function () {
        $pc(function () {
            $scope.objLocale = {};
            $scope.objLocale.RowNo = '';
            $scope.objLocale.LocaleCd = $scope.data.CboLocalesSeleted;
            $scope.objLocale.ItemName = '';
            $scope.objLocale.FileCd = '';
            $scope.objLocale.HasGen = true;
            $scope.objLocale.Notes = '';
            $scope.objLocale.MetaTitle = '';
            $scope.objLocale.MetaDesc = '';
            $scope.objLocale.MetaKeys = '';
            $scope.changedLocaleCd($scope.objLocale.LocaleCd);
        });
    };
    // Xử lý select thông tin dòng
    $scope.selectRow = function (idx) {
        $pc(function () {
            // Clear thông tin dòng
            $scope.clearRow();
            // Khởi tạo biến cục bộ
            var tmp = {};
            var obj = {};
            // Kiểm tra chỉ số dòng
            if ($scope.objEntry.ListLocale.length > idx && idx > -1) {
                obj = $scope.objEntry.ListLocale[idx];
                angular.copy(obj, tmp);
                $scope.objLocale = tmp;
            } else if ($scope.objEntry.ListLocale.length > 0
                && $scope.objEntry.ListLocale.length === $scope.data.CboLocales.length) {
                obj = $scope.objEntry.ListLocale[0];
                angular.copy(obj, tmp);
                $scope.objLocale = tmp;
            }
        });
    };
    // Xử lý copy thông tin chính
    $scope.copyInfo = function () {
        var fnYes = function () {
            $pc(function () {
                $scope.objLocale.ItemName = $scope.objEntry.DataInfo.ItemName;
                $scope.objLocale.Notes = $scope.objEntry.DataInfo.Notes;
                $scope.objLocale.MetaTitle = $scope.objEntry.DataInfo.MetaTitle;
                $scope.objLocale.MetaDesc = $scope.objEntry.DataInfo.MetaDesc;
                $scope.objLocale.MetaKeys = $scope.objEntry.DataInfo.MetaKeys;
            });
        };
        $dialogHelper.showDialogConfirm($ms('I.MSG.00002'), fnYes);
    };
    // Xử lý thay đổi tên
    $scope.blurItemName = function (data, obj, genlink) {
        $pc(function () {
            if (genlink) {
                $scope.genLinkName(obj);
            }
            $scope.genSearchName(obj);
        });
    };
    // Xử lý thay đổi ngôn ngữ
    $scope.changedLocaleCd = function (data) {
        $pc(function () {
            var rowData = $dataHelper.getRowData(data, $scope.data.CboLocales, 'Code');
            $scope.objLocale.LocaleName = rowData.Name;
        });
    };
    // Tạo tự động tên liên kết
    $scope.genLinkName = function (obj) {
        if ($checkHelper.isNull(obj.LinkName)) {
            obj.LinkName = $dataHelper.toLinkName(obj.ItemName);
        }
    };
    // Tạo tự động tên tìm kiếm
    $scope.genSearchName = function (obj) {
        obj.SearchName = $dataHelper.toSearchName(obj.ItemName);
    };
    /* Định nghĩa các events */
    // Ẩn/Hiện cửa sổ chính
    $scope.$parent.showViewMain(false);
    // Tiến hành xử lý init
    $scope.init();
    /* Đăng ký các events */
    // $watch('objLocale.LocaleCd')
    $scope.$watch('objLocale.LocaleCd', function (newValue, oldValue) {
        if (newValue) {
            $scope.changedLocaleCd(newValue);
        }
    });
} ]);