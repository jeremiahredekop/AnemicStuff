using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anemeicEvents.Models;

namespace anemicEvents.Denormalization
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateDb();

        }

        private static void GenerateDb()
        {
            var things = Enumerable.Range(0, 1000)
                .Select(i => new EquipmentEntity {EquipmentId = Guid.NewGuid(), Name = "equipment # " + i});

            var something = new RelaySeeder<ReadContext>(context =>
                context.Equipment.AddOrUpdate(things.ToArray()));

            Database.SetInitializer(something);

            var task = new ReadContext().Equipment.ToListAsync();
            task.Wait();

            Console.Write(task.Result.Count);
        }
    }
}
