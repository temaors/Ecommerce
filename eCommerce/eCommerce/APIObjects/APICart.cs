using eCommerce.Database.DbEntities;

namespace eCommerce.APIObjects;

public class APICart
{
    public int UserId { get; set; }
    public List<Product> Products { get; set; }
    public int Count() => Products.Count;
}