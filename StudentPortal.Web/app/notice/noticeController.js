app.controller("noticeController", function ($scope,$rootScope,noticeService,$location) {
    $scope.notice = [];
    $scope.noticeData = {};
    $scope.getNotice = function () {
        noticeService.getNotices().then(function (result) {
            $scope.notice = result.data.value;
        }, function (error) {
            alert(error);
        });
    }
    $scope.addNotices = function () {
        var today = new Date();
        var date = today.getFullYear() + '-' + "0" + (today.getMonth() + 1) + '-' + "0" + today.getDate();
        alert(date);
        $scope.noticeData.PostingDate = date;
        $scope.noticeData.TID = $rootScope.userData.TeachID;
        noticeService.postNotices($scope.noticeData).then(function (result) {
            alert("Notice Added successfully");
            $location.path('/Dashboard');
            $scope.noticeData = {};
        }, function (error) {
            alert("Addition Failed");
        });
    }
    $scope.noticeDetail = [];
    $scope.view = function (index) {
        var filter = "?$filter=";
        filter = filter + "NID eq " + index;
        alert(filter);
        noticeService.showNotices(filter).then(function (result) {
            $scope.noticeDetail = result.data.value[0];
        })
    }
});