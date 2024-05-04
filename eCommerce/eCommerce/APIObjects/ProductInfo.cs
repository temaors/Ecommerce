namespace eCommerce.APIObjects
{
    public class ApiProductInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? SubcategoryId { get; set; }
        public double? Price { get; set; }
        public int? UnitId { get; set; }
        public double? Rating { get; set; }
        public string? Reference { get; set; }
    }
}