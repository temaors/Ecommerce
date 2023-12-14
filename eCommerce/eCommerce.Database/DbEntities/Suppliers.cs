namespace eCommerce.Database.DbEntities;

public class Suppliers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> ProductsList { get; set; }
}