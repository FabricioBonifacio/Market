angular.module('supermercadoApp').factory('notificationSharedService', function(){
	var notificationSharedService = {
		index: 0,
	    invalidNotification: false,
		notifications: {},
		add: function(notification){

	      var i;

	      if(!notification){
	        this.invalidNotification = true;
	        return;
	      }

	      i = this.index++;
	      this.invalidNotification = false;
	      this.notifications[i] = notification;
	    }
	};

	return notificationSharedService;
});