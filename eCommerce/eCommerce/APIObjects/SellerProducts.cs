namespace eCommerce.APIObjects;
using eCommerce.Infrastructure.Types.Enums;

public class ApiSellerProduct
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

public class ApiSellerProductsList
{
    public IEnumerable<ApiSellerProductsElement> Elements { get; set; }
}

public class ApiSellerProductsElement
{
    public int Count { get; set; }
    public ApiSellerProduct Product { get; set; }
}