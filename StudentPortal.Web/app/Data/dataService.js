app.factory("dataService", function ($http) {
    var dataServiceFactory = {};
    dataServiceFactory.addEducation = function (model) {
        return $http.post("http://localhost/Studentportal.Api/odata/Educations", model);
    }
    return dataServiceFactory;
});