using eCommerce.APIObjects;

namespace eCommerce.ViewModels;

public class UserProductViewModel
{
    public APIUser? User { get; set; }
    public List<APIProductInfo>? UserProducts { get; set; }
}