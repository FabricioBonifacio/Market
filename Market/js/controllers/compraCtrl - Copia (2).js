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
			$http.put("http://localhost:60624/api/Compra/" + compra.ID, compra).success(function(data) {
				carregarCompras();
			});
		}
		else{
			$http.post("http://localhost:60624/api/Compra", compra).success(function(data) {
				if(data != null){
					/*for(i = 0; i < data.Itens; i++){
						data.Itens[i].CompraID = data.ID;
						$http.post("http://localhost:60624/api/Item", data.Itens[i]).success(function(dataI) {
							
						});
					}*/
					carregarCompras();
				}
				
			});
		}
		delete $scope.compra;
		$scope.compraForm.$setPristine();
		document.getElementById('closeButton').click();
	};
	$scope.excluir = function(compra){
		$http.delete("http://localhost:60624/api/Item/" + compra.ID).success(function(data) {
			$http.delete("http://localhost:60624/api/Compra/" + compra.ID).success(function(data) {
				carregarCompras();
			});
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
		item.ValorTotal = item.Quantidade * item.ValorUnitario;
		/*if($scope.compra.ID > 0){
			if(item.ID > 0){
				
			}
			else{
				item.CompraID = $scope.compra.ID;
				$http.post("http://localhost:60624/api/Item", item).success(function(data) {
					carregarItens();
				});
			}
		}
		else{*/
			if(item.ID > 0){
				
			}
			else{
				$scope.compra.Itens.push(item);
			}
		//}
		delete $scope.item;
		$scope.itemForm.$setPristine();
		document.getElementById('closeButtonItem').click();
	};
	$scope.excluirItem = function(item){
		index = $scope.compra.Itens.indexOf(item);
		$scope.compra.Itens.splice(index,1);
	};
	$scope.editarItem = function(item){
		$scope.item = item;
	};
	$scope.novoItem = function(){
		delete $scope.item;
		$scope.itemForm.$setPristine();
	};
	/*Metodos*/
	var carregarItens = function(){
		$http.get("http://localhost:60624/api/Item/" + $scope.compra.ID).success(function(data) {
			$scope.compras = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarCompras = function(){
		$http.get("http://localhost:60624/api/Compra").success(function(data) {
			$scope.compras = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarFormasPagamento = function(){
		$http.get("http://localhost:60624/api/FormaPagamento").success(function(data) {
			$scope.formasPagamento = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarSupermercados = function(){
		$http.get("http://localhost:60624/api/Supermercado").success(function(data) {
			$scope.supermercados = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	var carregarProdutos = function(){
		$http.get("http://localhost:60624/api/Produto").success(function(data) {
			$scope.produtos = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};
	carregarFormasPagamento();
	carregarSupermercados();
	carregarCompras();
	carregarProdutos();	
});