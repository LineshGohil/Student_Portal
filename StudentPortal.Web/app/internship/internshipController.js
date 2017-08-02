app.controller("internshipController", function ($scope, $rootScope, $location, internshipService) {
    $scope.getInternshipDetail = {};
    $scope.insert = function () {
        $scope.getInternshipDetail.StudId = $scope.userData.StudId;
        internshipService.addinternship($scope.getInternshipDetail).then(function (result) {
            $scope.getInternshipDetail = {};
            alert("Data Added Successfully");
        }, function (error) {
            alert(error);
        });
    }
})