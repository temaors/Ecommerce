using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class SaleRepository : Repository<Sale>
{
    public SaleRepository(ECommerceDbContext context) : base(context)
    {
    }
}