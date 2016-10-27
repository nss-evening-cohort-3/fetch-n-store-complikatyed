"use strict";
app.controller("RequestCtrl", function ($scope) {

    $scope.responseStorage = [];
    
    $scope.doURLRequest = () => {
        console.log("Somebody clicked me!");
        AskStore.doStuff()
        .then(function (requestResults) {
            $scope.responseStorage = requestResults[0];
            console.log("Stuff happened");
        });
    }

});


