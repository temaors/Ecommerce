using eCommerce.Database.DbEntities;

namespace eCommerce.Database.Repositories;

public class AddressRepository: Repository<Address>
{
    public AddressRepository(ECommerceDbContext context) : base(context)
    {
    }
}