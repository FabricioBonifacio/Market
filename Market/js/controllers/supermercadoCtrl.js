angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.supermercados = [];
	$scope.adicionar = function(supermercado){
		if(supermercado.ID > 0){
			$http.put("http://localhost:8080/api/Supermercado/" + supermercado.ID, supermercado).success(function(data) {
				carregarSupermercados();
			});
		}
		else{
			$http.post("http://localhost:8080/api/Supermercado", supermercado).success(function(data) {
				carregarSupermercados();
			});
			//supermercado.ID = $scope.supermercados.length + 1;
			//$scope.supermercados.push(supermercado);
		}
		delete $scope.supermercado;
		$scope.supermercadoForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(supermercado){
		$http.delete("http://localhost:8080/api/Supermercado/" + supermercado.ID).success(function(data) {
			carregarSupermercados();
		});
		//index = $scope.supermercados.indexOf(supermercado);
		//$scope.supermercados.splice(index,1);
	};
	$scope.editar = function(supermercado){
		$scope.supermercado = supermercado;
	};
	$scope.novo = function(){
		delete $scope.supermercado;
		$scope.supermercadoForm.$setPristine();
	};
	/*Metodos*/
	var carregarSupermercados = function(){
		$http.get("http://localhost:8080/api/Supermercado").success(function(data) {
			$scope.supermercados = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	carregarSupermercados();
});