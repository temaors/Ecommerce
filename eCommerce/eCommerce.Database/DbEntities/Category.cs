namespace eCommerce.Database.DbEntities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
    }

    public class SubCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public List<Product>? Products { get; set; }
    }
}