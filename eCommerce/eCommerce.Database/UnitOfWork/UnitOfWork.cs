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
        }
        public UserRepository Users { get; private set; }
        public CategoryRepository Categories { get; set; }
        public SubcategoryRepository Subcategories { get; set; }
        public ProductRepository Products { get; set; }
        
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