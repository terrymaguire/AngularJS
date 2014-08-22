/// <reference path="angular.js" /

var app = angular.module("myApp", []);

app.value("appTitle", "My Angular Application");

app.value('user', {
    staffId: 101,
    fullName: "Maguire, Terry",
    connectionName: "Elements",
    locale: "de-CH"
});

app.controller("TestCtrl", function (appTitle) {
    
});