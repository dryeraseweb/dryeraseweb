using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using ServiceStack.ServiceHost;

namespace DryEraseWeb
{
    public class Whiteboard
    {
        public string Id { get; set; }
        private List<Comment> _comments;
        private List<Tag> _tags;
        public string Url
        {
            get { return Id; }
            set { Id = value; }
        }

        public List<Comment> Comments
        {
            get { return _comments ?? (_comments = new List<Comment>()); }
            set { _comments = value; }
        }

        public List<Tag> Tags
        {
            get { return _tags ?? (_tags = new List<Tag>()); }
            set { _tags = value; }
        }
    }

    public class ContentBase<T>
    {
        [BsonId]
        public T Id { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Updated { get; set; }
    }

    public class Tag : ContentBase<string>
    {
    }

    public class Comment : ContentBase<string>
    {
    }
}