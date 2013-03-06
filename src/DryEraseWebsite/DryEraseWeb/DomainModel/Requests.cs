using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace DryEraseWeb.DomainModel
{
    [Route("/comment", "POST")]
    public class CommentPost : IReturnVoid
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    [Route("/tag", "POST")]
    public class TagPost : IReturnVoid
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    [Route("/whiteboard/{Url}", "GET")]
    public class WhiteboardRequest : IReturn<Whiteboard>
    {
        public string Url { get; set; }
    }

}