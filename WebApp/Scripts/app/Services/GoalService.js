app.factory('goalService',function($http){
    var postGoal = function(goalModel){
        $http({
            method: "POST",
            url: "http://localhost:25965/api/goal",
            data: { name: goalModel.Name, date: goalModel.Date, reward: goalModel.Reward,targets: goalModel.Targets, steps: goalModel.Steps }
        }).then(function mySuccess(response) {
            alert("Goal created");
        });
    }

    return {
        postGoal:postGoal
    };
});