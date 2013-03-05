 

var onload = function()
{
	alert('hello');

}

function appendHTML() {
        var wrapper = document.createElement("aside");
        wrapper.id = 'wrapper'
        wrapper.innerHTML = '\
<h1 style="margin-top: 100px">Hello World</h1\
';
        $('body').prepend(wrapper);

        $( "#wrapper" ).position({
  my: "left top",
  at: "right top",
  of: "body[0]"
});
    }

// if (document.readyState != 'loading')
{
	// onload();
	appendHTML();
}