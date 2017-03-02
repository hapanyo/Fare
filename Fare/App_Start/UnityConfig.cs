using System.Web.Http;
using System.Web.Mvc;
using Fare.Models;
using Fare.Models.Cost;
using Fare.Models.Interfaces;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Fare
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICalculator, Calculator>();
            container.RegisterType<ICost, DummyCost>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}