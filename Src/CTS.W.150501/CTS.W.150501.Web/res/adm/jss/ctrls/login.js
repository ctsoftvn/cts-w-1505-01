// LoginCtrl
ctrls.controller('LoginCtrl', ['$scope', '$state', '$window', function ($scope, $state, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.style = {};
    $scope.variable = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            url: '/ajx/adm-login.aspx/InitLayout',
            data: {},
            success: function (data) {
                if (data.HasAuth === true) {
                    $window.open('/adm/main.html', '_self');
                } else {
                    $scope.data = data;
                    $ti();
                }
            }
        });
    };
    // Xử lý xác thực
    $scope.auth = function () {
        $pc({
            url: '/ajx/adm-login.aspx/Auth',
            data: {
                UserName: $scope.data.UserName,
                Password: $scope.data.Password
            },
            success: function (data) {
                $window.open('/adm/main.html', '_self');
            }
        });
    };

    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
} ]);