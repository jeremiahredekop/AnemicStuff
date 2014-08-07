using System;
using System.Data.Entity;

namespace anemicEvents.Denormalization
{
    public class RelaySeeder<T> : CreateDatabaseIfNotExists<T> where T : DbContext
    {
        private readonly Action<T> _func;

        public RelaySeeder(Action<T> func)
        {
            _func = func;
        }

        protected override void Seed(T context)
        {
            _func(context);
        }
    }
}