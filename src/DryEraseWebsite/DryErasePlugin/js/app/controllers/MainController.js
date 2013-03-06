'use strict';

DryErasePlugin.controller('MainController', function MainController($scope, $http) {
   
    $http.get('http://DryEraseWeb-Dev/api/whiteboard/blah', function(data) {
        $scope.whiteboard = data;
        $scope.comments = data.comments;
        $scope.$apply();
    },
    function(error) {
        console.log(JSON.stringify(error));
    }),

    $scope.postComment = function() {
    };
    
    $scope.removeComment = function () {
    };

    $scope.addTag = function () {
    };
    
    $scope.removeTag = function () {
    };
});
