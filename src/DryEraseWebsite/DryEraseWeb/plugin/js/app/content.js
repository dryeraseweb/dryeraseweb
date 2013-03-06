

var DryEraseService = {
    load: function() {


        chrome.extension.sendMessage({ type: "badge", count: '4' }, function(response) {
//            console.log(response.farewell);
        });
        //        chrome.browserAction.setBadgeText({ text: '4' });
       
    }
};

DryEraseService.load();