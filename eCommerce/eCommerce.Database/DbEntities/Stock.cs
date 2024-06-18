namespace eCommerce.Database.DbEntities;

public class Stock
{
    public int Id { get; set; }
    public Address Address { get; set; }
    public List<Product> Products { get; set; }
}