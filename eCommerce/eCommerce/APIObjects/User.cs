using eCommerce.Database.DbEntities;
using eCommerce.Infrastructure.Types;
using eCommerce.Infrastructure.Types.Enums;

namespace eCommerce.APIObjects;

public class ApiUser : UserResponse
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public UserType Type { get; set; }
    public Currency Currency { get; set; }
}

public class UserResponse
{
    public int Id { get; set; }
}

public class UserFavouritesResponse
{
    public int Id { get; set; }
}