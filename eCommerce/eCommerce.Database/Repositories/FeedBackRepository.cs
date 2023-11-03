using eCommerce.Database.DbEntities;

namespace eCommerce.Database.Repositories;

public class FeedBackRepository : Repository<FeedBack>
{
    public FeedBackRepository(ECommerceDbContext context) : base(context)
    { }
}