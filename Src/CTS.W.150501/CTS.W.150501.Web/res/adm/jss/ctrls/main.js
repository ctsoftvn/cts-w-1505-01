// MainCtrl
ctrls.controller('MainCtrl', ['$scope', '$state', '$window', function ($scope, $state, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.style = {};
    $scope.variable = {};
    $scope.treeNavBar = {};
    // Gán giá trị init
    $scope.data.HasAuth = false;
    $scope.variable.showHideLeftPane = 1;
    $scope.treeNavBar.Options = { nodeChildren: 'Childs', dirSelectable: false };
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            url: '/ajx/adm-main.aspx/InitLayout',
            data: {},
            success: function (data) {
                if (data.HasAuth === false) {
                    $window.open('/adm/login.html', '_self');
                } else {
                    $scope.data = data;
                    $scope.treeNavBar.ListData = $dataHelper.toMenu(data.ListNavBar);
                }
            }
        });
    };
    // Xử lý logout
    $scope.logout = function () {
        $pc({
            url: '/ajx/adm-main.aspx/Logout',
            success: function () {
                $window.open('/adm/login.html', '_self');
            }
        });
    };
    // Hiển thị cửa sổ trái
    $scope.showLeftPane = function () {
        $pc(function () {
            $scope.variable.showHideLeftPane = 1;
            $('#navBarPane').animate({ marginLeft: '0' }, 200);
            $('#logoPane').animate({ marginLeft: '0' }, 200);
            $('#contentPane').animate({ marginLeft: '230px' }, 200);
        });
    };
    // Ẩn thị cửa sổ trái
    $scope.hideLeftPane = function () {
        $pc(function () {
            $scope.variable.showHideLeftPane = 0;
            $('#navBarPane').animate({ marginLeft: '-230px' }, 200);
            $('#logoPane').animate({ marginLeft: '-230px' }, 200);
            $('#contentPane').animate({ marginLeft: '0' }, 200);
        });
    };
    // Ẩn/Hiện cửa sổ trái
    $scope.showHideLeftPane = function () {
        $pc(function () {
            if ($scope.variable.showHideLeftPane === 0) {
                $scope.showLeftPane();
            } else {
                $scope.hideLeftPane();
            };
        });
    };
    // Xử lý thay đổi kích thước element
    $scope.resize = function () {
        $pc(function () {
            $('#navBarPane').height($(window).height() - 120);
        });
    };
    // Ẩn/Hiện cửa sổ chính
    $scope.showViewMain = function (flagShowHide) {
        $pc(function () {
            if (flagShowHide) {
                $('#mainContent').show();
            } else {
                $('#mainContent').hide();
            }
        });
    };
    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
    // Tiến hành thay đổi kích thước element
    $scope.resize();
    /* Đăng ký các events */
    // window.resize
    angular.element(window).bind('resize', function () {
        $scope.resize();
    });
} ]);