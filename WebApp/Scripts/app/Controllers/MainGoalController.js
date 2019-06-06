app.controller('MainGoalController', ['drawGraphService','goalCreatorService','$scope','$http',function (graphDrawer,goalCreatorService,$scope, $http) {
    $scope.step = 0;
    $scope.addCp = true;

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

    $scope.changeTree = function(index){
        $scope.stepTree = $scope.toAdd.Steps[index];
    }

    $scope.addCpToTree = function(newCp){
        if($scope.stepTree.tasks==null)
            $scope.stepTree.tasks = [];

        $scope.stepTree.tasks.push({name:newCp.name,date: newCp.date});

        $scope.stepTree.tasks.sort(function(task1,task2){
            return task1.date>task2.date?1:-1;
        });

        newCp.name = null;
        newCp.data = null;
        $scope.newCp = false;
        $scope.drawGraph();
    }

    $scope.drawGraph = function(){
        var nodes = [];
        

        if( $scope.stepTree.tasks == undefined){
            nodes.push(['Now','Step end']);
        }
        else{
            var tasks = $scope.stepTree.tasks;
            for(var i = 0;i<tasks.length;i++)
            {
                if(i == 0)
                    nodes.push(['Now',tasks[i].name]);
                else
                    nodes.push([tasks[i-1].name,tasks[i].name]);
            }
            nodes.push([tasks[tasks.length-1].name,'Step end']);
        }

        graphDrawer.drawGraph(nodes);
    }
}]);