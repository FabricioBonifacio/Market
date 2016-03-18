angular.module('supermercadoApp').directive('ngInfo', function(){
	return{
		templateUrl: "pages/info.html",
		replace: false,
		restrict: 'E'
	};
});