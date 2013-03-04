using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Routing;
using DryEraseWeb.Service.WebHost.App_Start;
using ServiceStack.Logging;
using ServiceStack.MiniProfiler;

//using ServiceStack.Mvc.MiniProfiler;

namespace DryEraseWeb.Service.WebHost
{
    public class Global : HttpApplication
    {
        private ILog log;

      /*  public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("index.html");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("service/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}" // URL with parameters
                //new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }*/

        protected void Application_Start(object sender, EventArgs e)
        {
//            ICollection configureAndWatch = XmlConfigurator.Configure();

//            log4net.ILog logger = log4net.LogManager.GetLogger(typeof (Global));

//            logger.Debug("Started logging");

            AppHost.Start();

            log = LogManager.GetLogger(GetType());

//            AreaRegistration.RegisterAllAreas();
//
//            RegisterGlobalFilters(GlobalFilters.Filters);
//            RegisterRoutes(RouteTable.Routes);
            

        }

        protected void Session_Start(object sender, EventArgs e)
        {
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           /* if (Request.IsLocal)
            {
                Profiler.Start(ProfileLevel.Verbose);
//                MiniProfiler
            }*/
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
//            Profiler.Stop();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Get the exception object.
            Exception exc = Server.GetLastError();

            // Handle HTTP errors
            if (exc.GetType() == typeof (HttpException))
            {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                //                Server.Transfer("HttpErrorPage.aspx");
            }

            // For other kinds of errors give the user some information
            // but stay on the default page
            //            Response.Write("<h2>Global Page Error</h2>\n");
            //            Response.Write(
            //                "<p>" + exc.Message + "</p>\n");
            //            Response.Write("Return to the <a href='Default.aspx'>" +
            //                "Default Page</a>\n");

            // Log the exception and notify system operators
            log.Error("DefaultPage", exc);
            //            ExceptionUtility.NotifySystemOps(exc);

            // Clear the error from the server
            Server.ClearError();
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}