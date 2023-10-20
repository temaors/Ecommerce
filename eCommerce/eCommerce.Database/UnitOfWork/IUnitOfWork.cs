using eCommerce.Database.Repositories;

namespace eCommerce.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    UserRepository Users { get; }
        
    int Complete();
}