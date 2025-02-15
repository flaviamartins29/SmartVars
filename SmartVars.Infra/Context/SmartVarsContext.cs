using Microsoft.EntityFrameworkCore;
using SmartVars.Domain.Entities;

namespace SmartVars.Infra.Data.Context
{
    public class SmartVarsContext : DbContext
    {
        public SmartVarsContext(DbContextOptions<SmartVarsContext> options) : base(options)
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            modelBuilder.UseInMemoryDatabase(databaseName : "SmartVars_Data");
        }
        public DbSet<BuildingVars> BuildingVars { get; set; }
    }
}
