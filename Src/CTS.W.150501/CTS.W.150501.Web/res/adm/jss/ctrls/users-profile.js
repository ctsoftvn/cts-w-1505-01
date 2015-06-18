// UsersProfileCtrl
ctrls.controller('UsersProfileCtrl', ['$scope', '$state', '$window', function ($scope, $state, $window) {
    /* Định nghĩa biến toàn cục */
    $scope.data = {};
    $scope.style = {};
    $scope.variable = {};
    // Gán giá trị init
    /* Định nghĩa phương thức xử lý */
    // Xử lý init
    $scope.init = function () {
        $pc({
            url: '/ajx/adm/users/profile.aspx/InitLayout',
            data: {},
            success: function (data) {
                if (data.HasAuth === false) {
                    $window.open('/adm/main.html', '_self');
                } else {
                    $scope.data = data;
                    $ti();
                }
            }
        });
    };
    // Xử lý save
    $scope.save = function () {
        $pc({
            url: '/ajx/adm/users/profile.aspx/Save',
            data: {
                Password: $scope.data.Password,
                NewPassword: $scope.data.NewPassword,
                ConfirmPassword: $scope.data.ConfirmPassword
            },
            success: function (data) {
            }
        });
    };

    /* Định nghĩa các events */
    // Tiến hành xử lý init
    $scope.init();
} ]);