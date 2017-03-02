using Fare.Models;
using Fare.Models.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fare
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();

            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);
           
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICalculator, Calculator>();
            container.RegisterType<ICost, NYCost>();
        }
    }
}
