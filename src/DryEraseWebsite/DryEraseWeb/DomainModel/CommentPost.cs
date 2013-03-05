using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace DryEraseWeb
{

    public class Whiteboard
    {
        public string Url { get; set; }
        public List<Comment> Comments { get; set; }  
        public List<Tag> Tags { get; set; }  
    }

    public class ContentBase
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Updated { get; set; }
    }

    public class Tag : ContentBase
    {
    }

    public class Comment : ContentBase
    {
        
    }
}