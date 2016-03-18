angular.module('supermercadoApp').controller('produtoCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.produtos = [];
	$scope.categorias = [];
	$scope.unidades = [];
	$scope.adicionar = function(produto){
		if(produto.ID > 0){
			produto.UnidadeID = produto.Unidade.ID;
			produto.CategoriaID = produto.Categoria.ID;
			$http.put("http://localhost:8080/api/Produto/" + produto.ID, produto).success(function(data) {
				carregarProdutos();
			});
		}
		else{
			$http.post("http://localhost:8080/api/Produto", produto).success(function(data) {
				carregarProdutos();
			});
		}
		delete $scope.produto;
		$scope.produtoForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(produto){
		$http.delete("http://localhost:8080/api/Produto/" + produto.ID).success(function(data) {
			carregarProdutos();
		});
	};
	$scope.editar = function(produto){
		$scope.produto = produto;
	};
	$scope.novo = function(){
		delete $scope.produto;
		$scope.produtoForm.$setPristine();
	};
	/*Metodos*/
	var carregarCategorias = function(){
		$http.get("http://localhost:8080/api/Categoria").success(function(data) {
			$scope.categorias = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarUnidades = function(){
		$http.get("http://localhost:8080/api/Unidade").success(function(data) {
			$scope.unidades = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarProdutos = function(){
		$http.get("http://localhost:8080/api/Produto").success(function(data) {
			$scope.produtos = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	carregarCategorias();
	carregarUnidades();
	carregarProdutos();
});