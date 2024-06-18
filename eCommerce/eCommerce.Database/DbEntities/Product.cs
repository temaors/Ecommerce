using eCommerce.Infrastructure.Types.Enums;

namespace eCommerce.Database.DbEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public string? Reference { get; set; }
        public Units Unit { get; set; }
        public int? SubCategoryId { get; set; }
        public double? Rating { get; set; }
        public SubCategory? SubCategory { get; set; }
        public List<FeedBack>? FeedBacks { get; set; }
        public double Volume { get; set; }
    }
}