app.factory('internshipService', function ($http) {
    var internshipServiceFactory = {};
    internshipServiceFactory.addinternship = function (model) {
        return $http.post("http://localhost/Studentportal.Api/odata/Interships", model);
    }
    return internshipServiceFactory;
})