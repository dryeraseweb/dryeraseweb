using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace DryEraseWeb
{
    [Route("/comment")]
    public class Comment : IReturnVoid
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}