using System.ComponentModel.DataAnnotations;

namespace eCommerce.Database.DbEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int UnitId { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<FeedBack>? FeedBacks { get; set; }
    }
}