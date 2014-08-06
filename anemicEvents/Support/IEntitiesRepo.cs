using System;
using System.Linq;

namespace anemicEvents.api
{
    public interface IEntitiesRepo
    {
        object Get(string entityTypeName, Guid id);
        IQueryable<object> GetQuery(string entityTypeName);
        void Save(SaveModel save);
    }
}