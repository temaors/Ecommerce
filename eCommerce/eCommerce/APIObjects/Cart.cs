using eCommerce.Database.DbEntities;

namespace eCommerce.APIObjects;

public class ApiCart
{
    public int UserId { get; set; }
    public List<ApiCartElement> Products { get; set; }
}

public class ApiCartElement
{
    public Product Product { get; set; }
    public int Count { get; set; }
}

public class ApiCartResponse
{
    public int Id { get; set; }
}