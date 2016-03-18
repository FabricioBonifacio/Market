angular.module('supermercadoApp').controller('formaPagamentoCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.formasPagamento = [];
	$scope.adicionar = function(formaPagamento){
		if(formaPagamento.ID > 0){
			$http.put("http://localhost:8080/api/FormaPagamento/" + formaPagamento.ID, formaPagamento).success(function(data) {
				carregarFormasPagamento();
			});
		}
		else{
			$http.post("http://localhost:8080/api/FormaPagamento", formaPagamento).success(function(data) {
				carregarFormasPagamento();
			});
		}
		delete $scope.formaPagamento;
		$scope.formaPagamentoForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(formaPagamento){
		$http.delete("http://localhost:8080/api/FormaPagamento/" + formaPagamento.ID).success(function(data) {
			carregarFormasPagamento();
		});
	};
	$scope.editar = function(formaPagamento){
		$scope.formaPagamento = formaPagamento;
	};
	$scope.novo = function(){
		delete $scope.formaPagamento;
		$scope.formaPagamentoForm.$setPristine();
	};
	/*Metodos*/
	var carregarFormasPagamento = function(){
		$http.get("http://localhost:8080/api/FormaPagamento").success(function(data) {
			$scope.formasPagamento = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	carregarFormasPagamento();
});