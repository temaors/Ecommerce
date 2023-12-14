namespace eCommerce.Database.DbEntities
{
    public class FeedBack
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string? Text { get; set; }
        public double? Mark { get; set; }
    }
}