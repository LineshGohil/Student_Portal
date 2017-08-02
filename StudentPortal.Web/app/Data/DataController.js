app.controller('DataContoller', function ($scope,$rootScope,dataService,$location) {
    
    $scope.getData = {};
    $scope.insert = function () {
        $scope.getData.StudId = $rootScope.userData.StudId;
        //$scope.getData.TenthLink = $scope.get($scope.getData.TenthLink);
        //$scope.getData.TwelthLink = $scope.get($scope.getData.TwelthLink);
        //$scope.getData.PolytechnicLink = $scope.get($scope.getData.PolytechnicLink);
        //$scope.getData.FirstSemLink = $scope.get($scope.getData.FirstSemLink);
        //$scope.getData.SecondSemLink = $scope.get($scope.getData.SecondSemLink);
        //$scope.getData.ThirdSemLink = $scope.get($scope.getData.ThirdSemLink);
        //$scope.getData.ForthSemLink = $scope.get($scope.getData.ForthSemLink);
        //$scope.getData.FifthSemLinkk = $scope.get($scope.getData.FifthSemLinkk);
        //$scope.getData.SixthSemLink = $scope.get($scope.getData.SixthSemLink);
        //$scope.getData.SeventhSemLink = $scope.get($scope.getData.SeventhSemLink);
        //$scope.getData.EigthSemLink = $scope.get($scope.getData.TenthLink);
        dataService.addEducation($scope.getData).then(function (result) {
            $scope.getData = {};
            alert("Data Added Successfully");
        }, function (error) {
            alert(error);
        });
    }

    //$scope.get = function (Email) {
    //    if (!Email) {

    //    }
    //    else {
    //        var arr = Email.split("/");
    //        var fileId = arr[5];
    //        var idealLink = "https://drive.google.com/uc?export=download&id";
    //        var downLink = idealLink.concat("=", fileId);
    //        alert(downLink);
    //        return downLink;
    //    }
    //}

    $scope.workshop = function () {
        $location.path("/workshop");
    }

});