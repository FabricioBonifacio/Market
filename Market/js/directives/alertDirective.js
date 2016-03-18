angular.module('supermercadoApp').directive('ngAlerta', function(){
	return{
		templateUrl: "pages/alerta.html",
		replace: true,
		restrict: 'E'
	};
});