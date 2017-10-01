app.controller("noticeController", function ($scope, $rootScope, noticeService, $location, localStorageService) {
    $scope.notice = [];
    $scope.noticeData = {};
 
   $scope.getNotice = function () {
        noticeService.getNotices().then(function (result) {
            $scope.notice = result.data.value;
        }, function (error) {
            alert(error);
        });
    }
    $rootScope.$on('updateHeader', function () {
        alert($rootScope.student);
        if (localStorageService.get('userDetail')) {
            $rootScope.userData = localStorageService.get('userDetail');
            $location.path('/Dashboard');
            $scope.show = false;
            alert($rootScope.student);
            $rootScope.student = localStorage.getItem('check');
            alert(localStorage.getItem('check'));
            alert($rootScope.student);
        }
    })

    $scope.addNotices = function () {
        var today = new Date();
        if (today.getDate() > 9) {
            var date = today.getFullYear() + '-' + "0" + (today.getMonth() + 1) + '-' + today.getDate();
        }
        else {
            var date = today.getFullYear() + '-' + "0" + (today.getMonth() + 1) + '-' + "0" + today.getDate();
        }
        $scope.noticeData.PostingDate = date;
        $scope.noticeData.TID = $rootScope.userData.TeachID;
        noticeService.postNotices($scope.noticeData).then(function (result) {
            alert("Notice Added successfully");
            $location.path('/Dashboard');
            $scope.reloadPage = function () { window.location.reload(); }
            $scope.noticeData = {};
        }, function (error) {
            alert("Addition Failed");0
        });
    }
    $scope.noticeDetail = [];
    $scope.view = function (index) {
        $location.path('/NoticeDetail');
        localStorage.setItem('noticeData',index);
        //$rootScope.$broadcast('DetailValue');


        //var filter = "?$filter=";
        //filter = filter + "NID eq " + index;
        //noticeService.showNotices(filter).then(function (result) {
        //    $scope.noticeDetail = result.data.value[0];
        //    $scope.detail = $scope.noticeDetail.Detail;
        }
    
});