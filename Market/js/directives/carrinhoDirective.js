angular.module('deliveryApp').directive('ngCarrinho', function(){
	return{
		templateUrl: "view/modalCarrinho.html",
		replace: true,
		restrict: 'E'
	};
});