app.factory('goalCreatorService',['goalSplitService','goalService', function(goalSplitService,goalService){
    var changeStep = function(step,goalModel){
        if(step == 1){
            if(goalModel.Steps!=null)
                return;

            goalModel.Steps = goalSplitService.splitGoal(goalModel.Date,3);
        }
        else if(step == 2){
            goalService.postGoal(goalModel);
        }
    }

    return{
        changeStep: changeStep
    };
}]);