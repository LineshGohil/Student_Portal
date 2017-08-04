app.controller('headerController', function ($scope, $rootScope, headerService, $location) {
    $rootScope.userData = [];
    $scope.show = true;
    $scope.student = true;
    $scope.loginData = [];
    $scope.login = function () {
        var a = 1;
        
        headerService.getUsers().then(function (result) {
            $scope.user = result.data.value;
            angular.forEach($scope.user, function (value, key) {
                if (value.Email == $scope.loginData.Email && value.Passward == $scope.loginData.Password) {
                    $location.path('/Dashboard');
                    $rootScope.userData = value;
                    a = 0;
                    $scope.show = false;
                    $sccop.student = false;
                }
                else if ((a == 1) && ($scope.user.length - 1) == key) {
                    var b = 1;
                    headerService.getTeachers().then(function (teacher) {
                        $scope.Teachers = teacher.data.value;
                        angular.forEach($scope.Teachers, function (val, key) {
                            if (val.Email == $scope.loginData.Email && val.Passward == $scope.loginData.Password) {
                                $location.path('/Dashboard');
                                $scope.show = false;
                                $scope.student = true;
                            }
                            else {
                                alert("sdsddgd");
                            }
                        }, function (err) { alert(err); }
                        )
                    })
                }
            }, function (err) {
                alert(err);
            }
        )
        })
    }
});