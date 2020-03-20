using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData;



namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
         
            config.Select().Expand().Filter().OrderBy().MaxTop(10000).Count();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Microsoft.NAV.customer>("Customers");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "oData",
                model: builder.GetEdmModel());

        }
    }
}
