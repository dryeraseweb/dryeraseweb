using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DryEraseWeb.DomainModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace DryEraseWeb
{
    public class DryEraseService : ServiceStack.ServiceInterface.Service
    {
        private DryEraseWebDbService _dryEraseWebDbService;

        public DryEraseService()
        {
            _dryEraseWebDbService = new DryEraseWebDbService();
        }


        public void Post(CommentPost aCommentPost)
        {
            _dryEraseWebDbService.AddComment(aCommentPost.Url,
                                             new Comment()
                                                 {
                                                     Id = aCommentPost.Url,
                                                     Posted = DateTime.UtcNow,
                                                     Updated = DateTime.UtcNow,
                                                     Text = aCommentPost.Text
                                                 });
        }


        public void Post(TagPost aCommentPost)
        {
            _dryEraseWebDbService.AddTag(aCommentPost.Url,
                                             new Tag()
                                             {
                                                 Id = aCommentPost.Url,
                                                 Posted = DateTime.UtcNow,
                                                 Updated = DateTime.UtcNow
                                                 ,
                                                     Text = aCommentPost.Text
                                             });
        }

        public Whiteboard Get(WhiteboardRequest aWhiteboardRequest)
        {
            return _dryEraseWebDbService.GetWhiteboard(aWhiteboardRequest.Url);
        }
    }


    public class DryEraseWebDbService : BaseDbService
    {
        public void AddComment(string url, Comment comment)
        {
            var whiteboard = GetWhiteboard(url);

            if (null == whiteboard)
            {
                whiteboard = new Whiteboard() {Url = url};
            }

            whiteboard.Comments.Add(comment);

            GetCollection<Whiteboard>().Save(whiteboard);
        }

        public void AddTag(string url, Tag tag)
        {
            var whiteboard = GetWhiteboard(url);

            if (null == whiteboard)
            {
                whiteboard = new Whiteboard() {Url = url};
            }

            whiteboard.Tags.Add(tag);

            GetCollection<Whiteboard>().Save(whiteboard);
        }

        public Whiteboard GetWhiteboard(string url)
        {
            if (null == url)
            {
                throw new ArgumentNullException("url");
            }
            Whiteboard whiteboard = base.QueryById<Whiteboard>(url);

            return whiteboard;
        }
    }


    public class BaseDbService
    {
        private string _mondoDBName = "DryEraseWeb";
        protected string MongoConnectionString { get; set; }

        private MongoClient _mongoClient;


        public MongoClient MongoClient
        {
            get
            {
                if (null == _mongoClient)
                {
                    _mongoClient = new MongoClient(MongoConnectionString);
                }
                return _mongoClient;
            }
            set { _mongoClient = value; }
        }

        private MongoDatabase _urbanSafariMongoDatabase = null;

        public MongoDatabase UrbanSafariMongoDatabase
        {
            get
            {
                if (null == _urbanSafariMongoDatabase)
                {
                    _urbanSafariMongoDatabase = MongoClient.GetServer().GetDatabase(_mondoDBName);
                }
                return _urbanSafariMongoDatabase;
            }
        }

        public MongoCollection<T> GetCollection<T>()
        {
            return new MongoCollection<T>(UrbanSafariMongoDatabase,
                                          new MongoCollectionSettings<T>(UrbanSafariMongoDatabase, typeof (T).Name));
        }

        public BaseDbService()
        {
            MongoConnectionString = ConfigurationManager.AppSettings["MongoDBConnection"];
            _mondoDBName = ConfigurationManager.AppSettings["AppDatabase"];
        }

        public T QueryById<T>(string key) where T : new()
        {
            return GetCollection<T>().FindOneById(key);
        }

        public T QueryById<T>(int key) where T : new()
        {
            return GetCollection<T>().FindOneById(key);
        }

        public T QueryById<T>(long key) where T : new()
        {
            return GetCollection<T>().FindOneById(key);
        }
    }
}