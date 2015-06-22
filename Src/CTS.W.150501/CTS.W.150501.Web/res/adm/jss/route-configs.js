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
    // Settings|Info
    $stateProvider.state('settings_info', {
        url: "/adm/settings/info",
        views: {
            main: {
                templateUrl: "/cts/com/html/ucs/view-company-infos.html",
                controller: "ViewCompanyInfosCtrl"
            }
        }
    });
    // Settings|InfoSEO
    $stateProvider.state('settings_seo', {
        url: "/adm/settings/seo",
        views: {
            main: {
                templateUrl: "/cts/com/html/ucs/view-seo-infos.html",
                controller: "ViewSEOInfosCtrl"
            }
        }
    });
    // Settings|System
    $stateProvider.state('settings_system', {
        url: "/adm/settings/system",
        views: {
            main: {
                templateUrl: "/cts/com/html/ucs/view-parameters.html",
                controller: "ViewParametersCtrl"
            }
        }
    });
});