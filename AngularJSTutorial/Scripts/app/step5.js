/// <reference path="angular.js" /

var app = angular.module("step5App", []);

app.controller("TaskListCtrl", function ($scope, $http) {

    loadData();

    $scope.refresh = function () {
        loadData();
    };

    function loadData() {
        $http.get("/api/tasks").success(function (data) {
            $scope.tasks = data;
        }).error(function () {
            alert("an unexpected error occurred!");
        });
    }
});

app.controller("NewTaskCtrl", function ($scope, $http) {

    $scope.taskName = null;

    $scope.createTask = function () {

        var config = { 
            headers : { 
                "CommandType": "CreateTask"
                }
        };

        var data = { Name: $scope.taskName };

        $http.post("/api/tasks", data, config).success(function (data, status, headers) {

            alert("Task Added");
            $http.get(headers("location")).success(function (data) {
                $scope.tasks.push(data);
            });

        });
    };
});