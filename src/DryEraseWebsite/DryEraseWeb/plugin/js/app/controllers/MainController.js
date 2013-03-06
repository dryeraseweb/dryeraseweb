'use strict';

DryErasePlugin.controller('MainController', function MainController($scope, $http, $resource, $log, $location, Whiteboard, Comment, Tag) {

    $scope.comments = [];
    $scope.tags = [];

    $scope.tabUrl = '';


/*
    chrome.tabs.getSelected(function(tab) {
        $scope.tabUrl = encodeURIComponent(tab.url);
    });*/
    
    chrome.tabs.query({ active: true }, function (tab) {
        
        $scope.tabUrl = tab[0].url;
        $scope.getUrl = function () {
            return encodeURIComponent( $scope.tabUrl );
        };

        
        $scope.whiteboard = Whiteboard.get({ url: $scope.getUrl() }, function (whiteboard) {
            $scope.comments = whiteboard.Comments;
            $scope.tags = whiteboard.Tags;

            for (var i = 0; i < $scope.comments.length; i++) {

                var c = $scope.comments[i];
                c.posted_date = (new Date(parseInt(c.Posted.substr(6)))).toLocaleString();
                c.updated_date = new Date(parseInt(c.Updated.substr(6)));
            }
         
        }, function (error) {
            console.log(error);
        });
    });

   
   


    $scope.postComment = function () {
        if (!$scope.comment) {
            return;
        }
        Comment.save({}, { Url: $scope.getUrl(), Text: $scope.comment }, function() {
            $log.log('saved');

            $scope.comments.unshift({ Text: $scope.comment, Posted: new Date(), Updated: new Date() });
            $scope.comment = null;
        }, function(error) {
            $log.error('Failed due to error' + error);
        });
    };

    $scope.removeComment = function() {
        // TODO
    };

    $scope.addTag = function () {
        if (!$scope.tag) {
            return;
        }
        Tag.save({}, { Url: $scope.getUrl(), Text: $scope.tag }, function() {
            $log.log('saved tag');
            $scope.tags.push({ Text: $scope.tag });
            $scope.tag = null;
        }, function(error) {
            $log.error('Failed due to error' + error);
        });
    };

    $scope.removeTag = function() {
        // TODO
    };
});