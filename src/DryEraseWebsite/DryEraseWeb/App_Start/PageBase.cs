using System.Web.UI;
using Funq;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;


/**
 * Base ASP.NET WebForms page using ServiceStack's Compontents, see: http://www.servicestack.net/mvc-powerpack/
 */

namespace UrbanSafari.Service.WebHost.App_Start
{
	//A customizeable typed UserSession that can be extended with your own properties

    public class PageBase : Page
	{
		private Container _container;
		public Container Container
		{
			get { return _container ?? (_container = AppHostBase.Instance.Container); }
		}

		protected string SessionKey
		{
			get
			{
				var sessionId = SessionFeature.GetSessionId();
				return sessionId == null ? null : SessionFeature.GetSessionKey(sessionId);
			}
		}

		private CustomUserSession _userSession;
		protected CustomUserSession UserSession
		{
			get
			{
				if (_userSession != null) return _userSession;
				if (SessionKey != null)
					_userSession = this.Cache.Get<CustomUserSession>(SessionKey);
				else
					SessionFeature.CreateSessionIds();

				var unAuthorizedSession = new CustomUserSession();
				return _userSession ?? (_userSession = unAuthorizedSession);
			}
		}

		public void ClearSession()
		{
			_userSession = null;
			this.Cache.Remove(SessionKey);
		}

		public new ICacheClient Cache
		{
			get { return Container.Resolve<ICacheClient>(); }
		}

		public ISessionFactory SessionFactory
		{
			get { return Container.Resolve<ISessionFactory>(); }
		}

		private ISession session;
		public new ISession Session
		{
			get
			{
				return session ?? ( session = SessionFactory.GetOrCreateSession() );
			}
		}
		
		
	}
}