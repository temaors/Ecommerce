namespace eCommerce.APIObjects;

public class ApiCategory : CategoryResponse
{
    public string Name { get; set; }
    public Dictionary<int, string> Subcategories { get; set; }
}

public class CategoryResponse
{
    public int Id { get; set; }
}

public class AllCategoriesResponse
{
    public List<ApiCategory> Categories { get; set; }
}