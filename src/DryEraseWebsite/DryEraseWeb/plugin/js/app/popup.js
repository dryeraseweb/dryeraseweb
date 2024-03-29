'use strict';

//Register the the services with the 'DryErasePlugin' application
var DryErasePlugin = angular.module('DryErasePlugin', ['ngResource', 'ngCookies']);


DryErasePlugin.constant('I18N.MESSAGES', {
    'login.error.notAuthorized': "You do not have the necessary access permissions.  Do you want to login as someone else?",
    'login.error.notAuthenticated': "You must be logged in to access this part of the application."
});

//All items attached to $rootScope are global
DryErasePlugin.run(function($rootScope) {

    //register global getKeys() function
    $rootScope.getKeys = function(obj) {
        var keys = new Array();
        for (var key in obj) {
            if (typeof this[key] !== 'function') {
                keys.push(key);
            }
        }
        return keys;
    };

    //register global alert function
    $rootScope.alert = function(text) {
        alert(text);
    };
});

DryErasePlugin.config(function($routeProvider) {

    $routeProvider.
//	 //Forgot Controller
//	  when('/forgotPassword', {
//	  	controller: 'ForgotPasswordController',
//	  	templateUrl: '/Scripts/views/forgotPassword.html'
//	  }).
//	    //Reset Password Controller
//	  when('/resetPassword/:token', {
//	  	controller: 'ResetPasswordController',
//	  	templateUrl: '/Scripts/views/resetPassword.html'
//	  }).
//Register Controller
//	  when('/register', {
//	      //	      controller: 'RegisterController',
//	      templateUrl: '/views/register.html'
//	  }).
//
//    //Who We Are - Static
//      when('/who-we-are', {
//          templateUrl: '/Scripts/views/who-we-are.html'
//      }).
//    ///How it works - Static
//      when('/how-it-works', {
//          templateUrl: '/Scripts/views/how-it-works.html'
//      }).
//    //Help - Static
//      when('/help', {
//          templateUrl: '/Scripts/views/help.html'
//      }).
//Welcome
        when('/main', {
            controller: 'MainController',
            templateUrl: 'views/main.html'
        }).
        //Default to Event List
        otherwise({ redirectTo: '/main' });

});