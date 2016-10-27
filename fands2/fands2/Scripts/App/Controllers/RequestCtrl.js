"use strict";
app.controller("RequestCtrl", function ($scope) {

    $scope.requestedMethod = [];
    $scope.requestedUrl = [];
    
    $scope.doURLRequest = () => {
        someThing.someFunction()
        .then(function (requestResults) {
            $scope.resultsStorage = requestResults[0];
        });
    }

});

