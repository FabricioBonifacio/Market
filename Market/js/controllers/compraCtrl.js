angular.module('supermercadoApp').controller('compraCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	$scope.compras = [];
	$scope.supermercados = [];
	$scope.formasPagamento = [];
	$scope.produtos = [];
	$scope.adicionar = function(compra){
		compra.Valor = 0;
		for(i = 0; i <  compra.Itens.length; i++){
			compra.Valor += compra.Itens[i].Quantidade * compra.Itens[i].ValorUnitario;
		}
		if(compra.ID > 0){
			$http.put("http://localhost:8080/api/Compra/" + compra.ID, compra).success(function(data) {
				carregarCompras();
			});
		}
		else{
			$http.post("http://localhost:8080/api/Compra", compra).success(function(data) {
				carregarCompras();
			});
		}
		delete $scope.compra;
		$scope.compraForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(compra){
		$http.delete("http://localhost:8080/api/Compra/" + compra.ID).success(function(data) {
			carregarCompras();
		});
	};
	$scope.editar = function(compra){
		$scope.compra = compra;
	};
	$scope.novo = function(){
		delete $scope.compra;
		$scope.compraForm.$setPristine();
		$scope.compra = {
			Itens:[]
		};
	};
	//CONTROLE ITEM
	$scope.adicionarItem = function(item){
		var str = item.Quantidade;
		item.Quantidade = str.replace(',','.');
		item.ValorTotal = item.Quantidade * item.ValorUnitario;
		item.CompraID = $scope.compra.ID;
		
		if(item.ID > 0){
			$http.put("http://localhost:8080/api/Item/" + item.ID, item).success(function(data) {
				calculaValor();
			});
		}
		else{
			if($scope.compra.Itens.length > 0){
				item.Numero = $scope.compra.Itens[$scope.compra.Itens.length-1].Numero + 1;
			}
			else{
				item.Numero = 1;
			}
			$http.post("http://localhost:8080/api/Item", item).success(function(data) {
				if(data != null){
					$scope.compra.Itens.push(data);
					calculaValor();
				}
				
			});
		}
		delete $scope.item;
		$scope.itemForm.$setPristine();
		document.getElementById('closeButtonItem').click();
	};
	$scope.excluirItem = function(item){
		$http.delete("http://localhost:8080/api/Item/" + item.ID).success(function(data) {
			index = $scope.compra.Itens.indexOf(item);
			$scope.compra.Itens.splice(index,1);
			calculaValor();
		});
		
	};
	$scope.editarItem = function(item){
		$scope.item = item;
	};
	$scope.novoItem = function(){
		delete $scope.item;
		$scope.itemForm.$setPristine();
	};
	/*Metodos*/
	$scope.inserirItens = function(compra){
		$scope.compra = compra;
	};
	var carregarItens = function(){
		$http.get("http://localhost:8080/api/Item/" + $scope.compra.ID).success(function(data) {
			$scope.compras = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarCompras = function(){
		$http.get("http://localhost:8080/api/Compra").success(function(data) {
			$scope.compras = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarFormasPagamento = function(){
		$http.get("http://localhost:8080/api/FormaPagamento").success(function(data) {
			$scope.formasPagamento = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarSupermercados = function(){
		$http.get("http://localhost:8080/api/Supermercado").success(function(data) {
			$scope.supermercados = data;
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
	var calculaValor = function(){
		$scope.compra.Valor = 0;
		for(i = 0; i < $scope.compra.Itens.length; i++){
			$scope.compra.Valor += $scope.compra.Itens[i].ValorTotal;
		}
		$http.put("http://localhost:8080/api/Compra/" + $scope.compra.ID, $scope.compra).success(function(data) {
			carregarCompras();
		});
	};
	carregarFormasPagamento();
	carregarSupermercados();
	carregarCompras();
	carregarProdutos();	
});