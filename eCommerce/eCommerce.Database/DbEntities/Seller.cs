namespace eCommerce.Database.DbEntities
{
    public class Seller
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}