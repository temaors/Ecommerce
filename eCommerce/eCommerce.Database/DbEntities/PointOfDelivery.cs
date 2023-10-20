using System.ComponentModel.DataAnnotations;

namespace eCommerce.Database.DbEntities
{

    public class PointOfDelivery
    {
        [Key] public int Id { get; set; }
        public Address? Address { get; set; }
        public User? Owner { get; set; }
        public List<User>? Workers { get; set; }
    }
}