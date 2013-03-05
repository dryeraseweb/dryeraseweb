using System;
using System.Configuration;
using DryEraseWeb.Service.LinkedIn;
using Funq;
using MongoDB.Driver;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Configuration;
using ServiceStack.FluentValidation;
//using ServiceStack.Logging;
//using ServiceStack.Logging.Elmah;
//using ServiceStack.Logging.Log4Net;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
//using ServiceStack.Mvc.MiniProfiler;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Admin;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using LogManager = ServiceStack.Logging.LogManager;

//[assembly: WebActivator.PreApplicationStartMethod(typeof (UrbanSafari.Service.WebHost.App_Start.AppHost), "Start")]


/**
 * Entire ServiceStack Starter Template configured with a 'Hello' Web Service and a 'Todo' Rest Service.
 *
 * Auto-Generated Metadata API page at: /metadata
 * See other complete web service examples at: https://github.com/ServiceStack/ServiceStack.Examples
 */

namespace DryEraseWeb.Service.WebHost.App_Start
{
	public class AppHost : AppHostBase
	{
		public AppHost() //Tell ServiceStack the name and where to find your web services
			: base("ASP.NET Host", typeof(AppHost).Assembly )
		{
		}

		public override void Configure(Container container)
		{
			//Set JSON web services to return idiomatic JSON camelCase properties
//            JsConfig.EmitCamelCaseNames = true;
//			LogManager.LogFactory = new Log4NetFactory(true);


			//Uncomment to change the default ServiceStack configuration
			SetConfig(
				new EndpointHostConfig
					{
						ServiceStackHandlerFactoryPath = "api",
#if DEBUG

						DebugMode = true,
						//Show StackTraces when developing
						LogFactory = new DebugLogFactory(),
#endif
					} );

			
			container.Register<ICacheClient>( new MemoryCacheClient() );
			container.Register<ISessionFactory>( new SessionFactory( container.Resolve<ICacheClient>() ) );

			//Enable Authentication
			ConfigureAuth(container);

			Plugins.Add( new RequestLogsFeature { AtRestPath = "/logs", EnableResponseTracking = true } );

		}

		/* Uncomment to enable ServiceStack Authentication and CustomUserSession */

	
		private void ConfigureAuth(Container container)
		{
			Routes.Add<Auth>( "/auth" ).Add<Auth>( "/auth/{provider}" );

			var appSettings = new AppSettings();
			container.Register<IResourceManager>( appSettings );
			//Register all Authentication methods you want to enable for this web app.            
			Plugins.Add(
				new AuthFeature(
					() => new AuthUserSession(),
					//Use your own typed Custom UserSession type
					new IAuthProvider[]
						{
							new CredentialsAuthProvider(),  //HTML Form post of UserName/Password credentials
							new LinkedInAuthProvider(appSettings),
                            new FacebookAuthProvider(appSettings),
                            new TwitterAuthProvider(appSettings), 
							
						}));
            Plugins.Add( new SessionFeature());

			//Provide service for new users to register so they can login with supplied credentials.
			//			Plugins.Add( new RegistrationFeature() );

			//override the default registration validation with your own custom implementation            
			container.RegisterAs<RegistrationValidator, IValidator<Registration>>();
			


//            var connectionstring = ConfigurationManager.AppSettings["MongoDB"];
//            var dbName = ConfigurationManager.AppSettings["MongoDatabase"];
//
//            var mongoClient = new MongoClient(connectionstring);
//            var server = mongoClient.GetServer();
//            var db = server.GetDatabase(dbName);

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<IUserAuthRepository>(new InMemoryAuthRepository());
            container.Register<CommentService>(new CommentService());
//            container.Register<IUserAuthRepository>(new MongoDBAuthRepository(db, true));


			var authRepo = container.Resolve<IUserAuthRepository>();
//			var meetupDBService = container.Resolve<MeetupDbService>();
//			var cachingService = container.Resolve<CachingService>();

		}

		public static bool IsRunningOnMono()
		{
			return Type.GetType("Mono.Runtime") != null;
		}


		public static void Start()
		{
			new AppHost().Init();
		}
	}
}