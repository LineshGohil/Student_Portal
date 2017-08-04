app.controller("noticeController", function ($scope,$rootScope,noticeService) {
    $scope.notice = [];
    $scope.getNotice = function () {
        noticeService.getNotices().then(function (result) {
            $scope.notice = result.data.value;
        }, function (error) {
            alert(error);
        });
    }
});