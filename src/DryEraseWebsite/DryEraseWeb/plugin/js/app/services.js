angular.module('DryEraseServices', ['ngResource']).
    factory('Whiteboard', function($resource) {
        return $resource('https://DryEraseWeb-Dev/api/whiteboard/:url', {url:'@url'}, {
            get: { method: 'GET', isArray: false }
        });
    });