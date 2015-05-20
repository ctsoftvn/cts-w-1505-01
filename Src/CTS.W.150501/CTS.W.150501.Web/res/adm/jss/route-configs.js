// Cấu hình routeProvider
app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/adm/main.html");
    // Login
    $stateProvider.state('login',{
        url : '/adm/login.html'
    });
    // Dashboard
    $stateProvider.state('dashboard', {
        url: "/adm/dashboard",
        views: {
            main: {
                templateUrl: "/vws/adm/dashboard.html",
                controller: "DashboardCtrl"
            }
        }
    });
});