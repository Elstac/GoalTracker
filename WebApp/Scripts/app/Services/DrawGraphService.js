app.factory('drawGraphService', function(){
    return{
        drawGraph: function(nodes){
        Highcharts.chart('container', {
            chart: {
              type: 'networkgraph',
              plotBorderWidth: 1
            },
            title: {
              text: 'Networkgraph with random initial positions'
            },
            plotOptions: {
              networkgraph: {
                keys: ['from', 'to']
              }
            },
            series: [{
              layoutAlgorithm: {
                enableSimulation: false,
                initialPositions: function () {
                  var chart = this.series[0].chart,
                    width = chart.plotWidth,
                    height = chart.plotHeight;
          
                  this.nodes.forEach(function (node) {
                    // If initial positions were set previously, use that
                    // positions. Otherwise use random position:
                    node.plotX = node.plotX === undefined ?
                      Math.random() * width : node.plotX;
                    node.plotY = node.plotY === undefined ?
                      Math.random() * height : node.plotY;
                  });
                }
              },
              name: 'K8',
              data: nodes
            }]
          })
        }
    };
});
