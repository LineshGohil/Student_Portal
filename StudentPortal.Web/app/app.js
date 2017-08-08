var app = angular.module('StudentPortal', ['ngRoute']);
app.config(function ($routeProvider) {

    $routeProvider.when("/ViewNotice", {
        controller: "noticeController",
        templateUrl: "notice/viewNotice.html"
    });
    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "login/mega-try.html",
    });
    $routeProvider.when("/Data", {
        controller: "DataContoller",
        templateUrl: "Data/Data.html",
    });
    $routeProvider.when("/workshop", {
        controller: "workShopContoller",
        templateUrl: "workShop/workShop.html",
    });
    $routeProvider.when("/training", {
        controller: "trainingController",
        templateUrl:"training/training.html",
    });
    $routeProvider.when("/internship", {
        controller: "internshipController",
        templateUrl: "internship/internship.html",
    });
    $routeProvider.when("/Dashboard", {
        controller: "noticeController",
        templateUrl: "notice/dashboard.html",
    });
    $routeProvider.otherwise({

        redirectTo:'/login'
    });
});