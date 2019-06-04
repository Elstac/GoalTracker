app.controller('MainGoalController', ['goalCreatorService','$scope','$http',function (goalCreatorService,$scope, $http) {
    $scope.step = 0;

    $http({
        method: "GET",
        url: "http://localhost:25965/api/goal"
    }).then(function mySuccess(response) {
        $scope.mainGoals = response.data;
    }, function myError(response) {
        $scope.apiData = response.statusText;
    });

    $scope.toAdd ={};
    
    $scope.addTarget = function(target){
        if($scope.toAdd.Targets == null)
            $scope.toAdd.Targets = new Array();
        
        $scope.toAdd.Targets.push({name:target.name, value:target.value});
        document.getElementById('target-name').value = '';
        document.getElementById('target-value').value = null;
    }

    $scope.setStep = function(step){
        goalCreatorService.changeStep(step,$scope.toAdd);
        $scope.step = step;
    }
}]);