using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using anemicEvents.Entities;
using LinqToQuerystring;

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
        public object Get(string entityTypeName)
        {
            var type = GetType().Assembly.GetTypes().Single(type1 => type1.Name.EndsWith(entityTypeName));
            return GetInner(type);

        }

        private object GetInner(Type entityType)
        {
            var query = _repo.GetQuery(entityType.Name).OfType(entityType);
            var oDataQuery = "?" + HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString());
            var modified = query.LinqToQuerystring(entityType, oDataQuery);
            return modified;
        }

        public IHttpActionResult Put(SaveModel model)
        {
            _repo.Save(model);

            return Ok("yo");
        }
    }
}