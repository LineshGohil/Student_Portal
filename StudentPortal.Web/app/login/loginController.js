app.controller('loginController', function ($scope,$rootScope,userService,$location) {
    $scope.show = true;
    $scope.registerData = {};
            
     $scope.register = function () {
        userService.createUser($scope.registerData).then(function (result) {
            alert("Registration Successful Please login..");
            $scope.show = true;
            $scope.registerData = {};
        }, function (error) {
            alert("Registeration Failed");
        });
    }
});