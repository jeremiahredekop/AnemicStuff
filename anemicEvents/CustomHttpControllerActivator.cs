using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using anemeicEvents.Models;
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
                return new EntitiesController(new DbEntitiesRepo(new ReadContext()));
            }

            return (IHttpController)Activator.CreateInstance(controllerType);
        }
    }
}