app.controller("viewNoticeController", function ($scope, $rootScope, localStorageService, noticeService) {
    $scope.index = localStorage.getItem('noticeData');
    //$rootScope.$on('DetailValue', function () {
    //    if (localStorageService.get('noticeData')) {
    //        $scope.index = localStorageService.get('noticeData');
    //    }
    //})

    var filter = "?$filter=";
    filter = filter + "NID eq " + $scope.index;
    noticeService.showNotices(filter).then(function (result) {
        $scope.noticeDetail = result.data.value[0];
        $scope.detail = $scope.noticeDetail.Detail;
        $scope.Catogery = $scope.noticeDetail.Category;
        $scope.NoticeNumber = $scope.noticeDetail.NID;
        $scope.Subject = $scope.noticeDetail.SubOfNotice;
        $scope.Date = $scope.noticeDetail.PostingDate;
        $scope.link = $scope.noticeDetail.link;
        $scope.TeacherName = $scope.noticeDetail.TID;

    })


});