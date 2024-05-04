namespace eCommerce.APIObjects;

public class ApiSellersProduct
{
    public int SellerId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int SubcategoryId { get; set; }
    public double Price { get; set; }
    public int UnitId { get; set; }
}