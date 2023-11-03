using System.ComponentModel.DataAnnotations;

namespace eCommerce.Database.DbEntities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}