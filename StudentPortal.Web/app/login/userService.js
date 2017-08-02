app.factory('userService', function ($http) {
    var userServiceFactory = [];
    userServiceFactory.getUsers = function () {
        return ($http.get("http://localhost/Studentportal.Api/odata/Students"));
    }

    userServiceFactory.createUser = function (model) {
        return ($http.post("http://localhost/Studentportal.Api/odata/Students", model));
    }

    userServiceFactory.getTeachers = function () {
        return ($http.get("http://localhost/Studentportal.Api/odata/Teachers"));
    }
    return userServiceFactory;
});