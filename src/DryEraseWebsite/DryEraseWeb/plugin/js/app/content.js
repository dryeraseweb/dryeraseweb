

var DryEraseService = {
    load: function () {
//        alert(window.location);
//        $.post('http://DryEraseWeb-Dev/api/itemcount?format=json', { "Url": window.location.href}, function(data) {
        $.post('http://dryeraseweb.azurewebsites.net/api/itemcount?format=json', { "Url": window.location.href }, function (data) {

            var badge = data > 0 ? data.toString() : "";
            chrome.extension.sendMessage({ type: "badge", count: badge }, function(response) {
            });
        })
            
            .fail(function(error) {
                $log.log(error);
                alert("error");
            })
          ;        
       

    }
};

DryEraseService.load();