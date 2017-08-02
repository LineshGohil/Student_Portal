app.controller("workShopContoller", function ($scope, $rootScope, $location, workShopService) {
    $scope.getWorkshopDetial = {};
    $scope.insert = function () {
        $scope.getWorkshopDetial.StudId = $scope.userData.StudId;
        workShopService.addWorkshop($scope.getWorkshopDetial).then(function (result) {
            $scope.getWorkshopDetial = {};
            alert("Data Added Successfully");
        }, function (error) {
            alert(error);
        });
    }
    $scope.training = function () {
        $location.path("/training");
    };
});