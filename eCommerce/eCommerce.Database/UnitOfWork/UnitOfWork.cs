using System.Drawing;
using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;

namespace eCommerce.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
            Subcategories = new SubcategoryRepository(_context);
            Products = new ProductRepository(_context);
            Carts = new CartRepository(_context);
            DeliveryPoints = new PointOfDeliveryRepository(_context);
            Sales = new SaleRepository(_context);
            FeedBacks = new FeedBackRepository(_context);
            Sellers = new SellerRepository(_context);
        }
        public UserRepository Users { get; private set; }
        public CategoryRepository Categories { get; set; }
        public SubcategoryRepository Subcategories { get; set; }
        public CartRepository Carts { get; set; }
        public ProductRepository Products { get; set; }
        public PointOfDeliveryRepository DeliveryPoints { get; set; }
        public SaleRepository Sales { get; set; }
        public FeedBackRepository FeedBacks { get; set; }
        public SellerRepository Sellers { get; set; }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}