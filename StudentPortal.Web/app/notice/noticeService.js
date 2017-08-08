app.factory("noticeService", function ($http) {
    var noticeServiceFactory = [];
    noticeServiceFactory.getNotices = function () {
        return ($http.get("http://localhost/Studentportal.Api/odata/Notices"));
    }
    noticeServiceFactory.postNotices = function (model) {
        return ($http.post("http://localhost/Studentportal.Api/odata/Notices",model));
    }
    noticeServiceFactory.showNotices = function (model) {
        return ($http.get("http://localhost/Studentportal.Api/odata/Notices"+model));
    }
    return noticeServiceFactory;
})