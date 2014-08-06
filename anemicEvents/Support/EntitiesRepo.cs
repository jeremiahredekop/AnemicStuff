using System;
using System.Collections.Generic;
using System.Linq;
using anemicEvents.Entities;
using gcExtensions;

namespace anemicEvents.api
{
    public class EntitiesRepo : IEntitiesRepo
    {
        private readonly Dictionary<string, List<object>> _data;
        
        private static readonly EntitiesRepo _instance;


        static EntitiesRepo()
        {
            var data = Enumerable.Range(0, 100)
       .Select(i => new Entity1() { Id = Guid.NewGuid(), Number = i })
       .GroupBy(entity1 => entity1.GetType().Name);

            _instance = new EntitiesRepo(data);   
        }

        public static IEntitiesRepo WithDummyData()
        {
            return _instance;
        }

        public EntitiesRepo(IEnumerable<IGrouping<string, object>> data)
        {
            _data = data.ToDictionary(objects => objects.Key, objects => objects.ToList());
        }

        public object Get(string entityTypeName, Guid id)
        {
            return _data[entityTypeName].Single(o => (o as dynamic).Id == id);
        }

        public IQueryable<object> GetQuery(string entityTypeName)
        {
            return _data[entityTypeName].AsQueryable();
        }

        public void Save(SaveModel save)
        {
            var obj = save.Data.ToObject(GetType().Assembly.GetType(save.EntityName));
            var list = _data.GetOrCreateValue(save.EntityName,() => new List<object>());
            list.Add(obj);
        }
    }
}