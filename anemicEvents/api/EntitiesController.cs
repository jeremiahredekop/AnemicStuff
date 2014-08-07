using System;
using System.Linq;
using System.Web.Http;
using anemeicEvents.Models;

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
            return GetInner(entityTypeName);
        }

        private IQueryable GetInner(string entityTypeName)
        {
            var type = typeof(ReadContext).Assembly.GetTypes().Single(type1 => type1.Name.Contains(entityTypeName));
            return _repo.GetQuery(entityTypeName).OfType(type);
        }

        public IHttpActionResult Put(SaveModel model)
        {
            _repo.Save(model);

            return Ok("yo");
        }
    }
}