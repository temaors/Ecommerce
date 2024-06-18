using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;

namespace eCommerce.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ECommerceDbContext _context;
        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
            Users = new(_context);
            Categories = new(_context);
            Subcategories = new(_context);
            Products = new(_context);
            Carts = new(_context);
            DeliveryPoints = new(_context);
            Sales = new(_context);
            FeedBacks = new(_context);
            Sellers = new(_context);
            UsersAddresses = new(_context);
            CartElements = new(_context);
            UserFavourites = new(_context);
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
        public UsersAddressesRepository UsersAddresses { get; set; }
        public CartElementRepository CartElements { get; set; }
        public UserFavouritesRepository UserFavourites { get; set; }
        
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