using System.Runtime.Loader;
using System.ComponentModel.DataAnnotations;
namespace eCommerce.Database.DbEntities;

public class UsersAddresses
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Address>? Addresses { get; set; }
}