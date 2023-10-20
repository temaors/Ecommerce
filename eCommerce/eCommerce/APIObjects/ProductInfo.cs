namespace eCommerce.APIObjects
{
    public class ProductInfo
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public double Price { get; set; }
        public int UnitId { get; set; }
    }
}