Parse.initialize("BpZFyYu7pmfX6DZDRsnZo2YZdeg9jDNMWTThRN6V",
                 "NroRU6J1O73PQjmUWnxCPAi3BFynQJ1FQhnzyyog");

function getComments() {
	var Comment = Parse.Object.extend("Comment");
	var query = new Parse.Query(Comment);
	query.find({
		success: function(results) {
			console.log(results, "Success!");
			for (var i = results.length - 1; i >= 0; i--) {
				showComment(results[i]);
			};
			
	  	},
	  	error: function(error) {
			console.log("Failure!");
	  	}
	});
}

function saveComment(text) {
	var Comment = Parse.Object.extend("Comment");
	var comment = new Comment();
	comment.set("text", text);
	// comment.set("author", PFUser.User.current());
	
	comment.save(null, {
	  success: function(comment) {
	    // The object was saved successfully.
		console.log("Comment object was saved successfully");
	  },
	  error: function(comment, error) {
	    // The save failed.
	    // error is a Parse.Error with an error code and description.
		console.log("Failed to save comment object");
	  }
	});
}

function saveTag(title) {
	var Tag = Parse.Object.extend("Tag");
	var tag = new Tag();
	tag.set("title", text);
	// tag.set("author", PFUser.User.current());
	
	tag.save(null, {
	  success: function(comment) {
	    // The object was saved successfully.
		console.log("Comment object was saved successfully");
	  },
	  error: function(comment, error) {
	    // The save failed.
	    // error is a Parse.Error with an error code and description.
		console.log("Failed to save comment object");
	  }
	});
}

