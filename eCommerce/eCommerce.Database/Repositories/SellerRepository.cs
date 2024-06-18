using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class SellerRepository : Repository<Seller>
{
    public SellerRepository(ECommerceDbContext context) : base(context)
    {
    }

    public override async Task<Seller> GetById(int id)
    {
        return await base.GetAll()
            .Include(s => s.Products)
            .FirstOrDefaultAsync(seller => seller.Id == id);
    }
}