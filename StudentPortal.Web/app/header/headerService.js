app.factory('headerService', function ($http) {
    var headerServiceFactory = [];
    headerServiceFactory.getUsers = function () {
        return ($http.get("http://localhost/Studentportal.Api/odata/Students"));
    }
    headerServiceFactory.getTeachers = function () {
        return ($http.get("http://localhost/Studentportal.Api/odata/Teachers"));
    }
    return headerServiceFactory;
})