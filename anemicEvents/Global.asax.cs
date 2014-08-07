using System;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.OData.Extensions;

namespace anemicEvents
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "entitiesApi",
                    routeTemplate: "entities/{entityTypeName}/{id}",
                    defaults: new { id = RouteParameter.Optional, controller = "entities" }
                );

                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                config.AddODataQueryFilter();
                GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new CustomHttpControllerActivator());
            });         
        }
    }
}