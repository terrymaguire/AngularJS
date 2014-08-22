/// <reference path="angular.js" /

var app = angular.module("app", []);

app.controller("SampleCtrl", function ($scope, $q) {

    $scope.fail = false;

    $scope.test = function () {

        var deferred = $q.defer();

        var promise = deferred.promise;
        promise.then(function (result) {
            alert('Success: ' + result);
        }, function (reason) {
            alert('Error: ' + reason);
        });

        if ($scope.fail)
            deferred.reject('sorry');
        else
            deferred.resolve('Cool');
    };


    $scope.fail2 = false;
    $scope.test2 = function () {

        var deferred = $q.defer();

        var promise = deferred.promise;
        promise.then(function (result) {
            $scope.status2 = 'success pass 1 - ' + result;

            return result + ' hussa!';
        }, function (reason) {
            $scope.status2 = 'failure pass 1';
            return reason;
        })
        .then(function (result) {
            alert('Success: ' + result);
        }, function (reason) {
            alert('Error: ' + reason);
        });

        if ($scope.fail2)
            deferred.reject('Bad luck');
        else
            deferred.resolve('Hurray');
    };
});

