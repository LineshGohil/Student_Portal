app.factory("workShopService", function ($http) {
    var workShopServiceFactory = {};
    workShopServiceFactory.addWorkshop = function (model) {
        return $http.post("http://localhost/Studentportal.Api/odata/Workshops", model);
    }
    return workShopServiceFactory;
});