using Microsoft.EntityFrameworkCore;
using SkyDesign.Domain.Entities;

namespace SkyDesign.EntityFrameworkCore.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<SubCatalog> SubCatalog { get; set; }
        public DbSet<SubCatalogDetail> SubCatalogDetail { get; set; }        
    }
}
