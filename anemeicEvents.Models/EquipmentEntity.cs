using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace anemeicEvents.Models
{
    public class ReadContext : DbContext
    {
        public DbSet<EquipmentEntity> Equipment { get; set; }
    }


    public class EquipmentEntity
    {
        [Key]
        public Guid EquipmentId { get; set; }

        public string Name { get; set; }
    }
}
