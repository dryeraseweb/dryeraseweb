'use strict';

urbansafari.controller('RegisterController', function RegisterController($scope, $http, $cookies, $location, $routeParams) {
	

    $scope.FullName = null;
    $scope.registerUser = function () {
        AuthenticationService.register($scope.FullName, $scope.Email, $scope.Password).then(function (loggedIn) {
            if (!loggedIn) {
                $scope.authError = "Login failed.  Please check your credentials and try again.";
            }
            else {
                $('.dropdown.open').removeClass('open');
                $location.path('/event');
            }
        });
    }
	
});
