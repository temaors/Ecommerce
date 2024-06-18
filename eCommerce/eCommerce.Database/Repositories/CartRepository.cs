using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;
using eCommerce.Extensions.ExceptionExtensions;
namespace eCommerce.Database.Repositories;

public class CartRepository : Repository<Cart>
{
    public CartRepository(ECommerceDbContext context) : base(context)
    { }
    public override async Task<Cart> GetById(int id)
    {
        return await base.GetAll()
            .Include(c => c.Products)
            .ThenInclude(ce => ce.Product)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public override IQueryable<Cart> GetAll()
    {
        return base.GetAll()
            .Include(c => c.Products)
            .ThenInclude(ce => ce.Product)
            .AsNoTracking();
    }
}

public class CartElementRepository : Repository<CartElement>
{
    public CartElementRepository(ECommerceDbContext context) : base(context)
    {
    }
    
    public override IQueryable<CartElement> GetAll()
    {
        return base.GetAll()
            .Include(ce => ce.Product);
    }

    public override async Task<CartElement> GetById(int id)
    {
        return await base.GetAll()
            .Include(ce => ce.Product)
            .FirstOrDefaultAsync(ce => ce.Id == id);
    }
}