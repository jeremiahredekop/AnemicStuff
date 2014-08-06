using System;
using System.Linq;
using System.Reflection;

namespace anemicEvents.api
{
    public static class QueryableExtensions
    {
        public static IQueryable OfType(this IQueryable<object> query, Type type)
        {
            var method = typeof(Queryable).GetMethod("OfType", BindingFlags.Public | BindingFlags.Static);
            method = method.MakeGenericMethod(type);

            return (IQueryable) method.Invoke(null, new object[] {query});
        }
    }
}