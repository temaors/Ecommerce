using eCommerce.Database.DbEntities;

namespace eCommerce.Database.Repositories;

public class UserFavouritesRepository : Repository<UsersFavourites>
{
    public UserFavouritesRepository(ECommerceDbContext context) : base(context)
    {
    }
}