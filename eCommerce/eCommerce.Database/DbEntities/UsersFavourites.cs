namespace eCommerce.Database.DbEntities;
using System.ComponentModel.DataAnnotations;
public class UsersFavourites
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<int>? Products { get; set; }
}