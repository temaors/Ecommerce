using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<SubCategory>? SubCategories { get; set; }
        public virtual DbSet<Sale>? Sales { get; set; }
        public virtual DbSet<PointOfDelivery> PointOfDeliveries { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }
    }
}