using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedicineShop.Models
{
    public class MedicneDbContext:DbContext
    {
        public MedicneDbContext(DbContextOptions<MedicneDbContext> options):base(options)
        {

        }
        public DbSet<GenericGroup> GenericGroups { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
