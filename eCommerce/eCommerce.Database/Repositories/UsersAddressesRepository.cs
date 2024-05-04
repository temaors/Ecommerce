using eCommerce.Database.DbEntities;

namespace eCommerce.Database.Repositories;

public class UsersAddressesRepository : Repository<UsersAddresses>
{
    public UsersAddressesRepository(ECommerceDbContext context) : base(context)
    {
    }
}