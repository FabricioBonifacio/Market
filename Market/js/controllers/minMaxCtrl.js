angular.module('supermercadoApp').controller('minMaxCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.minMax = [];
	$scope.detalhesProduto = function(produto){
		$scope.produto = produto;
	};
	var carregarMinMax = function(){
		$http.get("http://localhost:60624/api/MinMax").success(function(data) {
			$scope.minMax = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	  $scope.labels = ["Perim", "ExtraBom - Top Life"];
	  $scope.series = ['Coca-Cola 1,5L'];
	  $scope.data = [
		[3.99, 3.69]
	  ];
	  $scope.cores = ['red','green'];
	  $scope.onClick = function (points, evt) {
		console.log(points, evt);
	  };
	/*var carregaGrafico = function(){
		Morris.Area({
		  element: 'myfirstchart',
		  data: [
			{x: '2010 Q4', y: 3, z: 7},
			{x: '2011 Q1', y: 3, z: 4},
			{x: '2011 Q2', y: null, z: 1},
			{x: '2011 Q3', y: 2, z: 5},
			{x: '2011 Q4', y: 8, z: 2},
			{x: '2012 Q1', y: 4, z: 4}
		  ],
		  xkey: 'x',
		  ykeys: ['y', 'z'],
		  labels: ['Y', 'Z']
		}).on('click', function(i, row){
		  console.log(i, row);
		});
	};*/
	carregarMinMax();
	//carregaGrafico();
});