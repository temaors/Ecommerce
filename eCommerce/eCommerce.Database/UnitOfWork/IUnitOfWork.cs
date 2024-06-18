using eCommerce.Database.DbEntities;
using eCommerce.Database.Repositories;

namespace eCommerce.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    UserRepository Users { get; }
    ProductRepository Products { get; set; }
    CategoryRepository Categories { get; set; }
    SubcategoryRepository Subcategories { get; set; }
    CartRepository Carts { get; set; }
    CartElementRepository CartElements { get; set; } 
    FeedBackRepository FeedBacks { get; set; }
    SaleRepository Sales { get; set; }
    PointOfDeliveryRepository DeliveryPoints { get; set; }
    SellerRepository Sellers { get; set; }
    UserFavouritesRepository UserFavourites { get; set; }
    int Complete();
}