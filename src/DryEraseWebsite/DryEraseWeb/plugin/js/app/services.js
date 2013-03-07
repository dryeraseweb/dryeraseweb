'use strict';
// 
// DEV 
/*DryErasePlugin.factory('Whiteboard', function ($resource) {
    return $resource('http://DryEraseWeb-Dev/api/whiteboard', {});
});

DryErasePlugin.factory('Comment', function ($resource) {
    return $resource('http://DryEraseWeb-Dev/api/comment', {  });
});

DryErasePlugin.factory('Tag', function ($resource) {
    return $resource('http://DryEraseWeb-Dev/api/tag', {  });
});*/

// Prod 
DryErasePlugin.factory('Whiteboard', function ($resource) {
    return $resource('http://dryeraseweb.azurewebsites.net/api/whiteboard', {});
});

DryErasePlugin.factory('Comment', function ($resource) {
    return $resource('http://dryeraseweb.azurewebsites.net/api/comment', {});
});

DryErasePlugin.factory('Tag', function ($resource) {
    return $resource('http://dryeraseweb.azurewebsites.net/api/tag', {});
});