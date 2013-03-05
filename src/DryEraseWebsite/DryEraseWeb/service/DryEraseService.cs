using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DryEraseWeb.DomainModel;
using ServiceStack.Text;

namespace DryEraseWeb
{
    public class DryEraseService : ServiceStack.ServiceInterface.Service
    {
        public void Post(CommentPost aCommentPost)
        {
            aCommentPost.PrintDump();
        }


        public void Post(TagPost aCommentPost)
        {
            aCommentPost.PrintDump();
        }

        public Whiteboard Get(WhiteboardRequest aWhiteboardRequest)
        {
            return new Whiteboard()
                {
                    Url = aWhiteboardRequest.Url,
                    Comments = new List<Comment>() {new Comment() {Text = "Blah"}, new Comment() {Text = "ABCDE"}},
                    Tags = new List<Tag>() {new Tag() {Text = "Blah"}, new Tag() {Text = "ABCDE"}}
                };
        }
    }
}