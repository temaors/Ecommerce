using eCommerce.APIObjects;

namespace eCommerce.ViewModels;

public class UserProductViewModel
{
    public ApiUser? User { get; set; }
    public List<ApiProductInfo>? UserProducts { get; set; }
}