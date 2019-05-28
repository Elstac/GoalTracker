var app = angular.module('myApp', []);

app.controller('myCtrl', function ($scope, $http) {
    $scope.postDependecies = new Array();
    $scope.addTask = false;

    $scope.getTasks = function () {
        $http({
            method: "GET",
            url: "http://localhost:25965/api/task"
        }).then(function mySuccess(response) {
            $scope.apiData = response.data;
        }, function myError(response) {
            $scope.apiData = response.statusText;
        });
    }

    $scope.getTasks();

    $scope.postHttp = function () {
        $http({
            method: "POST",
            url: "http://localhost:25965/api/task",
            data: { name: $scope.toAdd.Name, date: $scope.toAdd.Date, dependencyId: $scope.toAdd.DependencyId }
        }).then(function mySuccess(response) {
            $scope.getTasks();
            $scope.endAddingTask();
        });

        $scope.getTasks();
    }

    $scope.endAddingTask = function () {
        $scope.addTask = false;
        toAdd.Name = "";
        toAdd.DependencyId = 0;
        toAdd.Date = null;
    }

    $scope.completeTask = function (task) {
        $scope.apiData.forEach(function (t) {
            if (t.DependencyTasks != null) {
                t.DependencyTasks.forEach(function (dtask) {
                    if (dtask.Id === task.Id)
                        dtask.Completed = task.Completed;
                });
            }
        });
    }

    $scope.changeDependency = function (task, dependecies) {
        dependecies.add(task);
    }

    $scope.checkDepTasks = function (task) {
        if (task.DependencyTasks == null)
            return true;

        var notCompleted = task.DependencyTasks.find(function (dtask) {
            if (!(dtask.Completed))
                return dtask;
        });

        return (notCompleted == null);
    }
});