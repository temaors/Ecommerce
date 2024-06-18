namespace eCommerce.Database.DbEntities
{
    public class Address
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Bulding { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}