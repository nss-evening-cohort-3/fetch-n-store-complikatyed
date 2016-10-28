"use strict";
app.factory("AskStore", function ($q, $http) {

    var doStuff = function () {

        let responseStorage = [];
        let requestedMethod = document.getSelection("requestedMethod");
        let requestedURL = document.getElementById("requestedURL").value;

        return $q(function (resolve, reject) {

            $http.requestedMethod(requestedURL)

                .success(function (responseData) {
                   responseStorage.push(responseData);
                        resolve(queryStorage);
                })
                .error(function (error) {
                    reject(error);
                });

        });
    }

    return { doStuff: doStuff };
});