using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class PointOfDeliveryRepository : Repository<PointOfDelivery>
{
    public PointOfDeliveryRepository(ECommerceDbContext context) : base(context)
    {
    }
}