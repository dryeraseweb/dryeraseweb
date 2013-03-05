 


function appendHTML() {
  var wrapper = document.createElement("div");
  wrapper.id = 'plugWrap'
  wrapper.innerHTML = '<div class="tagWrap">\
  <a href="#">tag</a>\
  <a href="#">tag</a>\
  <a href="#">tag</a>\
</div>\
<form class="tagform" action="" method="get" accept-charset="utf-8">\
  <input type="text" name="some_name" value="add tag" id="some_name">\
  <input type="submit" value="Continue &rarr;">\
</form>\
<div id="cmntWrap">\
  <ul id="comments">\
    <li class="cf">\
      <img src="#" />\
      <p class="comment">this is what somebody says</p>\
      <p class="commentInfo">this is comment information</p>\
    </li>\
    <li class="cf">\
      <img src="#" />\
      <p class="comment">this is what somebody says</p>\
      <p class="commentInfo">this is comment information</p>\
    </li>\
  </ul>\
</div>\
<form class="tagform" action="" method="get" accept-charset="utf-8">\
  <input type="text" name="some_name" value="add comment" id="new_comment">\
  <input type="button" value="Continue &rarr;" id="post_comment">\
</form>';
  $('body').prepend(wrapper);

  // alert(wrapper);
}

function showComment(aComment){

  var li = '<li class="cf">\
      <img src="#" />\
      <p class="comment">' + aComment.attributes.text + '</p>\
      <p class="commentInfo">' + aComment.createdAt +'</p>\
    </li>';

    $('#comments').append( li );
   
}

function connectButtons()
{
    $('#post_comment').click(function() {
        saveComment($('#new_comment').val());
    }); 
} 

appendHTML();
connectButtons();
getComments();
//getComments();