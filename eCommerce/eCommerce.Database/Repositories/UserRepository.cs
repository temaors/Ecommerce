using eCommerce.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Database.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ECommerceDbContext context) : base(context)
        { }
    }
}