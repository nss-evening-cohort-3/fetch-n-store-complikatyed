"use strict";
app.controller("RequestCtrl", function ($scope, $http) {

    $scope.requestedMethod = document.getSelection("requestedMethod");
    $scope.requestedUrl = document.getElementById("requestedUrl").value;

    
    $scope.doUrlRequest = function (requestedMethod, requestedUrl) {

        var timeNow = Date.now();

        $http({
            method: $scope.requestedMethod,
            url: $scope.requestedUrl
        }).then(function (response) {

            $scope.status = response.status;
            $scope.responseTime = Date.now() - timeNow;

        }, function (response) {
            $scope.status = response.status;
        });
    };

    $scope.storeResponseData = function () {

        console.log("Store that puppy!");

    };
});







