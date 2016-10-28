"use strict";
app.controller("RequestCtrl", function ($scope, $http) {

    $scope.requestedMethod = document.getSelection("requestedMethod");
    $scope.requestedUrl =  document.getElementById("requestedUrl").value;
    
    $scope.doUrlRequest = function ( requestedMethod, requestedUrl ) {

        $http({
            method: $scope.requestedMethod,
            url: $scope.requestedUrl
        }).then(function (response) {

            $scope.status = response.status;

        }, function (response) {
            $scope.status = response.status;
        });
    }
});







