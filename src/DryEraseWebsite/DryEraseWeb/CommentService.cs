using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Text;

namespace DryEraseWeb
{
    public class CommentService : ServiceStack.ServiceInterface.Service
    {
        public Comment Get(Comment aComment)
        {
           return new Comment() {Url = aComment.Url, Text = "Blah"};
        }

        public void  Post(Comment aComment)
        {
            aComment.PrintDump();
        }   
    }
}