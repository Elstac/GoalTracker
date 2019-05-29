app.factory('newGoalService', function(){
    var newGoal;

    var createGoal = function(name,date,reward) {
        newGoal.name = name;
        newGoal.date = date;
        newGoal.reward = reward;
    };

    var getGoal = function(){
        return newGoal;
    };

    return {
        createGoal: createGoal,
        getGoal: getGoal
    };
});