angular.module('supermercadoApp').controller('categoriaCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.categorias = [];
	$scope.adicionar = function(categoria){
		if(categoria.ID > 0){
			$http.put("http://localhost:8080/api/Categoria/" + categoria.ID, categoria).success(function(data) {
				carregarCategorias();
			});
		}
		else{
			$http.post("http://localhost:8080/api/Categoria", categoria).success(function(data) {
				carregarCategorias();
			});
		}
		delete $scope.categoria;
		$scope.categoriaForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(categoria){
		$http.delete("http://localhost:8080/api/Categoria/" + categoria.ID).success(function(data) {
			carregarCategorias();
		});
	};
	$scope.editar = function(categoria){
		$scope.categoria = categoria;
	};
	$scope.novo = function(){
		delete $scope.categoria;
		$scope.categoriaForm.$setPristine();
	};
	/*Metodos*/
	var carregarCategorias = function(){
		$http.get("http://localhost:8080/api/Categoria").success(function(data) {
			$scope.categorias = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	carregarCategorias();
});