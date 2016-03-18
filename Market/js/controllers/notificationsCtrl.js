angular.module('supermercadoApp').controller('notificationsCtrl', function($scope, notificationSharedService){
	$scope.notifications = notificationSharedService;
});