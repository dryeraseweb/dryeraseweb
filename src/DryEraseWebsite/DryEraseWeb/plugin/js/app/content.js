

var DryEraseService = {
    load: function () {
//        alert(window.location);
        $.post('http://DryEraseWeb-Dev/api/itemcount?format=json', { Url: window.location.href}, function(data) {
          
            chrome.extension.sendMessage({ type: "badge", count: data.toString() }, function(response) {
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