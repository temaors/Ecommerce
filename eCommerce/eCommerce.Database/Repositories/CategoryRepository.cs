using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class CategoryRepository : Repository<Category>
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
}