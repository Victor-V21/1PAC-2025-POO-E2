using E1U2POO.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace E1U2POO.API.Database
{
    public class PlanillaDbContext : DbContext
    {
        public PlanillaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet <EmpleadoEntity> Empleados { get; set; }
        public DbSet <PlanillaEntity> Planilla { get; set; }
        public DbSet <DetallePlanillaEntity> Detalle { get; set; }
    }
}
