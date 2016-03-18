angular.module('deliveryApp').directive('ngPesquisa', function(){
	return{
		templateUrl: "view/pesquisa.html",
		replace: true,
		restrict: 'E'
	};
});