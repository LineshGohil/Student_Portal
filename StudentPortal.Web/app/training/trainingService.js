app.factory('trainingService', function ($http) {
    var trainingServiceServiceFactory = {};
    trainingServiceServiceFactory.addtraining = function (model) {
        return $http.post("http://localhost/Studentportal.Api/odata/Trainings", model);
    }
    return trainingServiceServiceFactory;
})