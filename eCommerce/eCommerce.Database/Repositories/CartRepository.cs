using eCommerce.Database.DbEntities;

namespace eCommerce.Database.Repositories;

public class CartRepository : Repository<Cart>
{
    public CartRepository(ECommerceDbContext context) : base(context)
    { }
}