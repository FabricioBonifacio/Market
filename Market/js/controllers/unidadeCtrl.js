angular.module('supermercadoApp').controller('unidadeCtrl', function($scope,$http,notificationSharedService){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.unidades = [];
	$scope.adicionar = function(unidade){
		if(unidade.ID > 0){
			$http.put("http://localhost:8080/api/Unidade/" + unidade.ID, unidade).success(function(data) {
				notificationSharedService.add("Unidade alterada com sucesso.");
				carregarUnidades();
			});
		}
		else{
			$http.post("http://localhost:8080/api/Unidade", unidade).success(function(data) {
				notificationSharedService.add("Unidade cadastrada com sucesso.");
				carregarUnidades();
			});
		}
		delete $scope.unidade;
		$scope.unidadeForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(unidade){
		$http.delete("http://localhost:8080/api/Unidade/" + unidade.ID).success(function(data) {
			carregarUnidades();
		});
	};
	$scope.editar = function(unidade){
		$scope.unidade = unidade;
	};
	$scope.novo = function(){
		delete $scope.unidade;
		$scope.unidadeForm.$setPristine();
	};
	/*Metodos*/
	var carregarUnidades = function(){
		$http.get("http://localhost:8080/api/Unidade").success(function(data) {
			$scope.unidades = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	carregarUnidades();
});