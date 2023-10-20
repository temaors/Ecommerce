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
        }
        public UserRepository Users { get; private set; }
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