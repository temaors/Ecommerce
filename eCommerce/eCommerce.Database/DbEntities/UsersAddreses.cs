using System.Runtime.Loader;

namespace eCommerce.Database.DbEntities;

public class UsersAddreses
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Address> Addresses { get; set; }
}