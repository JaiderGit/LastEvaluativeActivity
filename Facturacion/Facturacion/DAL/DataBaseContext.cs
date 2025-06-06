using Facturacion.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bill>().HasIndex(C=> C.Document).IsUnique();
        }

        #region

        public DbSet<Bill> Bills { get; set; }
        
        #endregion

    }
}
