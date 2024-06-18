using System.ComponentModel.DataAnnotations;

namespace eCommerce.Database.DbEntities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual List<CartElement>? Products { get; set; }
    }

    public class CartElement
    {
        [Key]
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}