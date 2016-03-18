angular.module('supermercadoApp').controller('infoCtrl', function($scope,$http){ /*angular.module('supermercadoApp').controller('supermercadoCtrl', function($scope, notificationSharedService){*/
	var carregarInfos = function(){
		$http.get("http://localhost:60624/api/Info").success(function(data) {
			$scope.info = data;
		}).error(function(data,status) {
			$scope.message = "Aconteceu um problema: " + data;
		});
	};

	carregarInfos();
});