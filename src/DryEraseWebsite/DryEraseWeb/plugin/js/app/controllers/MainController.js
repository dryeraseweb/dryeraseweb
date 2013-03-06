'use strict';

DryErasePlugin.controller('MainController', function MainController($scope, $http) {

    $scope.comments = [{ Text: 'Blah' }];

    $http.get('http://DryEraseWeb-Dev/api/whiteboard/blah').then( function(response) {
        $scope.whiteboard = response.data;
        $scope.comments = $scope.whiteboard.Comments;
//        $scope.$apply();
    },
    function(error) {
        console.log(JSON.stringify(error));
    }),

    $scope.postComment = function(comment) {
    };
    
    $scope.removeComment = function () {
    };

    $scope.addTag = function () {
    };
    
    $scope.removeTag = function () {
    };
});
