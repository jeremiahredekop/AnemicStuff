using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using anemicEvents.api;

namespace anemicEvents
{
    public class CustomHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            if (controllerType == typeof (EntitiesController))
            {
                return new EntitiesController(EntitiesRepo.WithDummyData());
            }

            return (IHttpController)Activator.CreateInstance(controllerType);
        }
     
    }
}