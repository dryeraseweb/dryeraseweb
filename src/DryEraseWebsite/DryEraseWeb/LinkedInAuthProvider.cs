using System;
using System.Collections.Generic;
using System.Net;
using ServiceStack.Common;
using ServiceStack.Configuration;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.Text;

namespace DryEraseWeb.Service.LinkedIn
{
    public class LinkedInAuthProvider : OAuthProvider
    {
        public const string Name = "linkedin";
        private const string MeetupAccessLevel = "r_fullprofile";
        public static string MeetupUserId = "MeetupUserId";
        public static string Realm = "https://secure.meetup.com/";

        public string Permissions { get; set; }

        public LinkedInAuthProvider(IResourceManager appSettings)
            : base(appSettings, Realm, Name)
        {
            this.Permissions = appSettings.GetString("oauth.{0}.Permissions".Fmt(Name));

            this.AuthorizeUrl = appSettings.GetString("oauth.{0}.AuthorizeUrl".Fmt(Name));
            this.AccessTokenUrl = appSettings.GetString("oauth.{0}.AccessTokenUrl".Fmt(Name));
        }

        public override object Authenticate(IServiceBase authService, IAuthSession session, Auth request)
        {
            object authenticate = base.Authenticate(authService, session, request);
            // Override the referrer url from config
            session.ReferrerUrl = this.RedirectUrl;
            return authenticate;
        }



        protected override void LoadUserAuthInfo(AuthUserSession userSession, IOAuthTokens tokens,
                                                 System.Collections.Generic.Dictionary<string, string> authInfo)
        {
            try
            {
                //downlaod custom meetup tokens // TODO
                tokens.UserId = userSession.UserAuthId;
                LoadUserOAuthProvider(userSession, tokens);
            }
            catch (Exception ex)
            {
                Log.Error("Could not retrieve meetup user info for '{0}'".Fmt(tokens.DisplayName), ex);
            }
        }

        public override void LoadUserOAuthProvider(IAuthSession authSession, IOAuthTokens tokens)
        {
            var userSession = authSession as AuthUserSession;
            if (userSession == null) return;

            //                        userSession.MeetupUserId = tokens.UserId ?? userSession.MeetupUserId;
            //                        userSession.MeetupUserName = tokens.UserName ?? userSession.MeetupUserName;
            userSession.DisplayName = tokens.DisplayName ?? userSession.DisplayName;
            userSession.FirstName = tokens.FirstName ?? userSession.FirstName;
            userSession.LastName = tokens.LastName ?? userSession.LastName;
            userSession.PrimaryEmail = tokens.Email ?? userSession.PrimaryEmail ?? userSession.Email;

        }
    }
}