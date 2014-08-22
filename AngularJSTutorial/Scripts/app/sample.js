/// <reference path="angular.js" /

var app = angular.module("sampleApp", []);

app.controller("SampleCtrl", function ($scope) {
    $scope.hello = "Hello Terry.";
});