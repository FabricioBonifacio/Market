angular.module('supermercadoApp').config(function($routeProvider){
	$routeProvider.when("/",{
		templateUrl: 'pages/mainContent.html'
	});
	$routeProvider.when("/compras",{
		templateUrl: 'pages/compras/compra.html'
	})
	$routeProvider.when("/unidades",{
		templateUrl: 'pages/cadastros/unidade.html'
	})
	$routeProvider.when("/produtos",{
		templateUrl: 'pages/cadastros/produto.html'
	})
	$routeProvider.when("/categorias",{
		templateUrl: 'pages/cadastros/categoria.html'
	})
	$routeProvider.when("/formasPagamento",{
		templateUrl: 'pages/cadastros/formaPagamento.html'
	})
	$routeProvider.when("/supermercados",{
		templateUrl: 'pages/cadastros/supermercado.html'
	})
});