using eCommerce.Database.DbEntities;

namespace eCommerce.Database.Repositories;

public class StockRepository: Repository<Stock>
{
    public StockRepository(ECommerceDbContext context) : base(context)
    {
    }
}