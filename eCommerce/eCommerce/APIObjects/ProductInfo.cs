using eCommerce.Infrastructure.Types.Enums;

namespace eCommerce.APIObjects
{
    public class ApiProductsList
    {
        public IEnumerable<ApiProductInfo> Products { get; set; }
    }
    
    public class ApiProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubcategoryId { get; set; }
        public double Price { get; set; }
        public Units Unit { get; set; }
        public double? Rating { get; set; }
        public string? Reference { get; set; }
        public string Manufacturer { get; set; }
        public double Volume { get; set; }
    }

    public class NewProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubcategoryId { get; set; }
        public double Price { get; set; }
        public Units Unit { get; set; }
    }

    public class CreatedProductResponse
    {
        public int Id { get; set; }
    }
}