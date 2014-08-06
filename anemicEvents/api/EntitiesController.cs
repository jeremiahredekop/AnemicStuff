using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;
using anemicEvents.Entities;
using Newtonsoft.Json;

namespace anemicEvents.api
{


    public class EntitiesController : ApiController
    {
        private readonly IEntitiesRepo _repo;

        public EntitiesController(IEntitiesRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public object Get(string entityTypeName, Guid id)
        {
            return _repo.Get(entityTypeName, id);
        }

        [HttpGet]
        public IQueryable Get(string entityTypeName)
        {
            var type = GetType().Assembly.GetTypes().Single(type1 => type1.Name.EndsWith(entityTypeName));
            return _repo.GetQuery(entityTypeName).OfType(type);
        }

       

        public IHttpActionResult Put(SaveModel model)
        {
            _repo.Save(model);

            return Ok("yo");
        }
    }
}