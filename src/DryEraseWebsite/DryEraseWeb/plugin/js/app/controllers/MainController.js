'use strict';

DryErasePlugin.controller('MainController', function MainController($scope, $http, $resource, $log, $location, Whiteboard, Comment, Tag) {


    $scope.whiteboard = Whiteboard.get({ url: 'abc123' }, function(whiteboard) {
        $scope.comments = whiteboard.Comments;
        $scope.tags = whiteboard.Tags;
    }, function(error) {
        console.log(error);
    });


    $scope.postComment = function() {
        Comment.save({}, { Url: $location.absUrl(), Text: $scope.comment }, function () {
            $log.log('saved');
            $scope.comments.unshift({ Text: $scope.comment });
            $scope.comment = null;
        }, function(error) {
            $log.error('Failed due to error' + error);
        });
    };

    $scope.removeComment = function() {
        // TODO
    };

    $scope.addTag = function() {
        Tag.save({}, { Url: $location.absUrl(), Text: $scope.tag }, function () {
            $log.log('saved tag');
            $scope.tags.push({  Text: $scope.tag });
            $scope.tag = null;
        }, function(error) {
            $log.error('Failed due to error' + error);
        });
    };

    $scope.removeTag = function() {
        // TODO
    };
});