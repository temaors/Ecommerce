using AutoMapper;
using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;


[Route("products")]
public class ProductsController : BaseECommerceController
{
    private readonly IMapper _mapper;
    
    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductsController> logger) 
        : base(unitOfWork, logger)
    {
        _mapper = mapper;
    }
    // [Route("view")]
    // [HttpGet]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<IActionResult> GetProducts(int id)
    // {
    //     var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
    //     ViewBag.Categories = categories;
    //     if (id == null)
    //     {
    //         return RedirectToAction("ViewProducts");
    //     }
    //     List<ApiProductInfo> products = new List<ApiProductInfo>();
    //
    //     foreach (var prod in _unitOfWork.Products.GetAll())
    //     {
    //         products.Add(new ApiProductInfo()
    //         {
    //             Id = prod.Id,
    //             Name = prod.Name,
    //             Description = prod.Description,
    //             Rating = Math.Round(prod.FeedBacks?.Average(p => p.Mark) ??  0.0, 1)
    //         });
    //     }
    //
    //     User? dbUser = await _unitOfWork.Users.GetById(id.Value);
    //     
    //     ApiUser apiUser = _mapper.Map<ApiUser>(dbUser);
    //     UserProductViewModel viewModel = new UserProductViewModel()
    //     {
    //         UserProducts = products,
    //         User = apiUser
    //     };
    //     ViewBag.Id = dbUser.Id;
    //     return View("ViewProducts", viewModel);
    // }
    
    [HttpGet]
    public async Task<ApiProductsList> ViewProducts()
    {
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
        List<ApiProductInfo> prods = new List<ApiProductInfo>();

        foreach (var prod in _unitOfWork.Products.GetAll())
        {
            prods.Add(new()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Reference = prod.Reference,
                Price = prod.Price,
                Rating = prod.Rating,
                Manufacturer = prod.Manufacturer,
                Volume = prod.Volume
            });
        }

        return new()
        {
            Products = prods
        };
    }

    [Route("add")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateProduct(ApiProductInfo apiProductInfo)
    {
        Product product = new()
        {
            Name = apiProductInfo.Name,
            Description = apiProductInfo.Description,
            Price = apiProductInfo.Price,
            Unit = apiProductInfo.Unit,
            SubCategoryId = apiProductInfo.SubcategoryId
        };
        await _unitOfWork.Products.Create(product);
        return Ok();
    }

    [Route("delete")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        await _unitOfWork.Products.Delete(productId);
        return Ok();
    }
    
    [HttpGet]
    [Route("view")]
    public async Task<ApiProductInfo> ViewProductDetails(int productId)
    {
        Product product = await _unitOfWork.Products.GetById(productId);
        ApiProductInfo productResult = _mapper.Map<ApiProductInfo>(product);
        return productResult;
    }
    
    [HttpPatch]
    [Route("add_to_favourites")]
    public async Task<IActionResult> AddToFavouritesList(int userFavouritesId, int productId)
    {
        var result = await _unitOfWork.UserFavourites.GetById(userFavouritesId);
        if (result.Products is null)
            result.Products = new ();
        result.Products.Add(productId);
        await _unitOfWork.UserFavourites.Save();
        return Ok();
    }
    
    [HttpPatch]
    [Route("remove_from_favourites")]
    public async Task<IActionResult> RemoveFromFavouritesList(int userFavouritesId, int productId)
    {
        var result = await _unitOfWork.UserFavourites.GetById(userFavouritesId);

        result.Products.Remove(productId);
        await _unitOfWork.UserFavourites.Save();
        return Ok();
    }
    
    [HttpGet]
    [Route("is_in_favourites")]
    public async Task<bool> IsInFavouritesList(int userFavouritesId, int productId)
    {
        var result = await _unitOfWork.UserFavourites.GetById(userFavouritesId);
        return result.Products.Contains(productId);
    }
    
    [HttpGet]
    [Route("favourites")]
    public async Task<ApiProductsList> GetFavourites(int userId)
    {
        UsersFavourites result = _unitOfWork.UserFavourites.GetAll().SingleOrDefault(item => item.UserId == userId);
        List<ApiProductInfo> prods = new List<ApiProductInfo>();
        
        foreach (int prodId in result.Products)
        {
            Product prod = await _unitOfWork.Products.GetById(prodId);
            prods.Add(new()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Reference = prod.Reference,
                Price = prod.Price,
                Rating = prod.Rating,
                Manufacturer = prod.Manufacturer,
                Volume = prod.Volume
            });
        }

        return new()
        {
            Products = prods
        };
    }
}