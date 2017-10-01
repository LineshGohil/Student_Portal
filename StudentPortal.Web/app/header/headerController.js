app.controller('headerController', function ($scope, $rootScope, headerService, $location, localStorageService) {
    $rootScope.userData = {};
    $scope.show = true;
    $rootScope.student = false;
    $scope.loginData = [];


    //Fetching Data from Local Storage
    $rootScope.$on('updateHeader', function () {
        if (localStorageService.get('userDetail')) {
            $rootScope.userData = localStorageService.get('userDetail');
            $location.path('/Dashboard');
            $scope.show = false;
        }
    })
    //if (localStorageService.get('check')) {
    //    $rootScope.student = localStorageService.get('check');
    //}
    if (localStorageService.get('userDetail')) {
        $rootScope.userData = localStorageService.get('userDetail');
        $scope.show = false;
        $rootScope.student = localStorage.getItem('check');
    }

    //End of local Storage
    $scope.login = function () {
        var a = 1;
        
        headerService.getUsers().then(function (result) {
            $scope.user = result.data.value;
            angular.forEach($scope.user, function (value, key) {
                if (value.Email == $scope.loginData.Email && value.Passward == $scope.loginData.Password) {
                    $location.path('/Dashboard');
                
                    localStorageService.set('userDetail', value);
                    // $rootScope.userData = value;
                    $rootScope.$broadcast('updateHeader');
                    localStorage.setItem('check', 'true');
                    a = 0;
                    $scope.show = false;
                    $rootScope.student = true;
                  //  localStorageService.set('check', student);
                  //  $rootScope.$broadcast('updateStudent');
                }
                else if ((a == 1) && ($scope.user.length - 1) == key) {
                    var b = 1;
                    headerService.getTeachers().then(function (teacher) {
                        $scope.Teachers = teacher.data.value;
                        angular.forEach($scope.Teachers, function (val, key) {
                            if (val.Email == $scope.loginData.Email && val.Passward == $scope.loginData.Password) {
                                $location.path('/Dashboard');
                                localStorageService.set('userDetail', val);
                                // $rootScope.userData = value;
                                $rootScope.$broadcast('updateHeader');
                                localStorage.setItem('check', 'false');
                               // $rootScope.userData = val;
                                $scope.show = false;
                                $rootScope.student = false;
                                $rootScope.$broadcast('updateHeader');
                            }
                            else {
                                loginData = [];
                                alert("Incorrect Credentials");
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
    $scope.logout = function () {
        localStorageService.remove('userDetail');
        $rootScope.userData = {};
        $location.path('/login');
        $scope.show = true;
        localStorage.clear();
    }
});