using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class SubcategoryRepository : Repository<SubCategory>
{
    public SubcategoryRepository(DbContext context) : base(context)
    {
    }
}