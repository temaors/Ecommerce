using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class SellerRepository : Repository<Seller>
{
    public SellerRepository(ECommerceDbContext context) : base(context)
    {
    }
}