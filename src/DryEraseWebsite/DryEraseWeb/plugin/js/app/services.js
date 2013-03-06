'use strict';

DryErasePlugin.factory('Whiteboard', function ($resource) {
    return $resource('http://DryEraseWeb-Dev/api/whiteboard/:url', { url: '@url' });
});

DryErasePlugin.factory('Comment', function ($resource) {
    return $resource('http://DryEraseWeb-Dev/api/comment', {  });
});

DryErasePlugin.factory('Tag', function ($resource) {
    return $resource('http://DryEraseWeb-Dev/api/tag', {  });
});