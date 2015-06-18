// Cấu hình routeProvider
app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/adm/main.html");
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
    // Master|Items|List
    $stateProvider.state('master_items_list', {
        url: "/adm/ma/items/list",
        views: {
            main: {
                templateUrl: "/vws/adm/ma/items/list.html",
                controller: "MAItemsListCtrl"
            }
        }
    });
    // Master|Items|Entry
    $stateProvider.state('master_items_entry', {
        url: "/adm/ma/items/entry",
        views: {
            main: {
                templateUrl: "/vws/adm/ma/items/entry.html",
                controller: "MAItemsEntryCtrl"
            }
        }
    });
    $stateProvider.state('master_items_list_entry', {
        url: "/adm/ma/items/entry/{Status}/{CallType}/{ItemCd}",
        views: {
            main: {
                templateUrl: "/vws/adm/ma/items/entry.html",
                controller: "MAItemsEntryCtrl"
            }
        }
    });
    // Users|Profile
    $stateProvider.state('users_profile', {
        url: "/adm/users/profile",
        views: {
            main: {
                templateUrl: "/vws/adm/users/profile.html",
                controller: "UsersProfileCtrl"
            }
        }
    });
});