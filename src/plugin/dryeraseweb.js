// Initialize Parse with your Parse application javascript keys
Parse.initialize("BpZFyYu7pmfX6DZDRsnZo2YZdeg9jDNMWTThRN6V",
                 "NroRU6J1O73PQjmUWnxCPAi3BFynQJ1FQhnzyyog");

var Comment = Parse.Object.extend("Comment", {

var query = new Parse.Query(Comment);
query.first({
	success: function(object) {
	    // Successfully retrieved the object.
		console.log(object, "success!");
	},
	error: function(error) {
		alert("Error: " + error.code + " " + error.message);
	}
});

});
