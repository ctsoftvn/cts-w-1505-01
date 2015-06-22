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
                    $scope.objLocale.LocaleCd = $scope.data.CboLocalesSeleted;
                    // Trường hợp kết quả trả về không phải mảng
                    if (!$.isArray($scope.objEntry.ListLocale)) {
                        $scope.objEntry.ListLocale = [];
                    }
                    // Xử lý select thông tin dòng đầu tiên
                    $scope.selectRow($scope.objLocale.LocaleCd);
                    // Xử lý focus
                    $ti('txtItemName');
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
    // Tạo mới mã
    $scope.genItemCd = function () {
        $pc({
            url: '/ajx/adm/ma/items/entry.aspx/GenItemCd',
            data: {
                Status: $scope.variable.BasicInfo.Status,
                CallType: $scope.variable.BasicInfo.CallType
            },
            success: function (data) {
                if ($scope.variable.BasicInfo.IsAdd && data.ItemCd) {
                    $scope.objEntry.DataInfo.ItemCd = data.ItemCd;
                }
            }
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
            // Trường hợp là ngôn ngữ chuẩn
            if ($scope.data.BasicLocale === obj.LocaleCd) {
                $dialogHelper.showDialogError($resourceHelper.getMessage('E.MSG.00004', 'ADM.MA.ITEMS.ENTRY.LocaleCd'));
                return;
            }
            // Cập nhật lại số dòng
            obj.RowNo = $gridHelper.getRowNo(obj.RowNo, $scope.objEntry.ListLocale);
            // Lấy chỉ số dòng trong mảng
            var rowIdx = $dataHelper.getRowIndex(obj.LocaleCd, $scope.objEntry.ListLocale, 'LocaleCd');
            if (rowIdx === -1) {
                // Thêm dữ liệu vào danh sách
                $scope.objEntry.ListLocale.push(obj);
            } else {
                // Cập nhật dữ liệu vào danh sách
                $scope.objEntry.ListLocale[rowIdx] = obj;
            }
            // Xử lý select thông tin dòng
            $scope.selectRow(obj.LocaleCd);
        });
    };
    // Xử lý clear thông tin dòng
    $scope.clearRow = function () {
        $pc(function () {
            $scope.objLocale.RowNo = '';
            $scope.objLocale.ItemName = '';
            $scope.objLocale.FileCd = '';
            $scope.objLocale.HasGen = true;
            $scope.objLocale.Notes = '';
            $scope.objLocale.MetaTitle = '';
            $scope.objLocale.MetaDesc = '';
            $scope.objLocale.MetaKeys = '';
        });
    };
    // Xử lý select thông tin dòng
    $scope.selectRow = function (localeCd) {
        $pc(function () {
            // Lấy chỉ số dòng trong mảng
            var rowIdx = $dataHelper.getRowIndex(localeCd, $scope.objEntry.ListLocale, 'LocaleCd');
            // Trường hợp không tồn tại dòng
            if (rowIdx === -1) {
                // Xử lý clear thông tin dòng
                $scope.clearRow();
            } else {
                // Khởi tạo biến cục bộ
                var tmp = {};
                var obj = $scope.objEntry.ListLocale[rowIdx];
                // Gán dữ liệu vào đối tượng
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
            // Lấy thông tin dữ liệu
            var rowData = $dataHelper.getRowData(data, $scope.data.CboLocales, 'Code');
            $scope.objLocale.LocaleName = rowData.Name;
            // Xử lý select thông tin dòng
            $scope.selectRow(rowData.Code);
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