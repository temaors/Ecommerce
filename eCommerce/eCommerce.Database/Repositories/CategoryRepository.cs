using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories;

public class CategoryRepository : Repository<Category>
{
    public CategoryRepository(ECommerceDbContext context) : base(context)
    {
    }
    
    public override IQueryable<Category> GetAll()
    {
        return base.GetAll().Include(c => c.SubCategories); // Жадная загрузка SubCategories
    }
}