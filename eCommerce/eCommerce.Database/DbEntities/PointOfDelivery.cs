using System.ComponentModel.DataAnnotations;

namespace eCommerce.Database.DbEntities
{

    public class PointOfDelivery
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public int UserId { get; set; }
        public User? Owner { get; set; }
        public List<User>? Workers { get; set; }
    }
}