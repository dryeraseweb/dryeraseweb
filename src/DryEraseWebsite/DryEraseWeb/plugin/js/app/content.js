

var DryEraseService = {
    load: function () {
        chrome.extension.sendMessage({ type: "badge", count: '4' }, function(response) {
        });

    }
};

DryEraseService.load();