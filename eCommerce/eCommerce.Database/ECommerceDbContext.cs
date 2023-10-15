using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database
{
    public sealed class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<User>? Users { get; set; }
    }
}