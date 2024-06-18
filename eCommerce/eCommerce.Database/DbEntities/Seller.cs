namespace eCommerce.Database.DbEntities
{
    public class Seller
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product>? Products { get; set; }
        public double CashAccount { get; set; }
        public List<Supplies>? Supplies { get; set; }
        public string? ManufacturerName { get; set; }
    }
}