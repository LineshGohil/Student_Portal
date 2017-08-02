app.controller('trainingController', function ($scope, $rootScope, $location,trainingService) {
    $scope.getTrainingDetail = {};
    $scope.insert = function () {
        $scope.getTrainingDetail.StudId = $scope.userData.StudId;
        trainingService.addtraining($scope.getTrainingDetail).then(function (result) {
            $scope.getTrainingDetail = {};
            alert("Data Added Successfully");
        }, function (error) {
            alert(error);
        });
    }
    $scope.internship = function () {
        $location.path("/internship");
    };
}
)