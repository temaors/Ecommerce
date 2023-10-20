using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}