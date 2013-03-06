
chrome.extension.onMessage.addListener(
    function(request, sender, sendResponse) {
        console.log(sender.tab ?
            "from a content script:" + sender.tab.url :
            "from the extension");
        if (request.type == "badge") {
            chrome.browserAction.setBadgeText({ text: request.count });
            sendResponse({ farewell: "goodbye" });
        }

    });