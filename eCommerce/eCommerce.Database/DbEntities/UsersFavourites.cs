namespace eCommerce.Database.DbEntities;

public class UsersFavourites
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Product> Products { get; set; }
}