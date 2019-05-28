app.controller('MainGoalController', function ($scope, $http) {
    $http({
        method: "GET",
        url: "http://localhost:25965/api/goal"
    }).then(function mySuccess(response) {
        $scope.mainGoals = response.data;
    }, function myError(response) {
        $scope.apiData = response.statusText;
    });

    $scope.postGoal = function () {
        $http({
            method: "POST",
            url: "http://localhost:25965/api/goal",
            data: { name: $scope.Name, date: $scope.Date, reward: $scope.Reward }
        }).then(function mySuccess(response) {
            alert("Goal created");
        });
    }
});