namespace eCommerce.Database.DbEntities
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int>? Products { get; set; }
        public double Price { get; set; }
    }
}