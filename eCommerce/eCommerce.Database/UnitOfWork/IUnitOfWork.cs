using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;

namespace eCommerce.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    UserRepository Users { get; }
    ProductRepository Products { get; set; }
    CategoryRepository Categories { get; set; }
    SubcategoryRepository Subcategories { get; set; }
    int Complete();
}