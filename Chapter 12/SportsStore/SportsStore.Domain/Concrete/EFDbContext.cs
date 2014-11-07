namespace SportsStore.Domain.Concrete
{
    using System.Data.Entity;
    using SportsStore.Domain.Entities;

    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
