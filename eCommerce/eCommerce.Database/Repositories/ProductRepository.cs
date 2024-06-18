using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;
using eCommerce.Extensions.ExceptionExtensions;
namespace eCommerce.Database.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(ECommerceDbContext context) : base(context)
    {
    }
    public override async Task<Product> GetById(int id)
    {
        if (id <= 0)
            throw ExceptionsFactory.InvArgException(
                System.Reflection.MethodBase.GetCurrentMethod()?.Name,
                $"Id = {id} is invalid. Id cannot be less than 1");

        Product objectFromDb = await _context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        if (objectFromDb is null)
        {
            throw ExceptionsFactory.DbObjectIsNullException(
                System.Reflection.MethodBase.GetCurrentMethod().Name,
                $"Object by id = {id} that you try to retrieve from {GetType().Name} repository is null");
        }

        return objectFromDb;
    }
}