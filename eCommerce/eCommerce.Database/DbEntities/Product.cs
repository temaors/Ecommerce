using System.ComponentModel.DataAnnotations;

namespace eCommerce.Database.DbEntities
{
    public class Product
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<FeedBack> FeedBacks { get; set; }
    }
}