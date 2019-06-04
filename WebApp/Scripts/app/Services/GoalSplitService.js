app.factory('goalSplitService', function(){
    var splitGoal = function(date,stepsNumber){
        var ret = new Array();
        var now = new Date();
        //Time span between Dates in days
        var timeDuration = Math.floor(((date - now)/(1000*60*60*24)));

        var tmp = timeDuration/stepsNumber;

        for(var i =0; i<stepsNumber-1;i++){
            var dateTmp = moment(now).add(tmp*(i+1),'day').format('YYYY-MM-DD');
            ret.push({name:'step' + (i+1), date:dateTmp});
        }
        ret.push({name:'step'+stepsNumber, date:moment(date).format('YYYY-MM-DD')});

        return ret;
    };

    return{
        splitGoal: splitGoal
    };
});