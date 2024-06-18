using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using eCommerce.Infrastructure.Types.Enums;

namespace eCommerce.Controllers;

[Route("seller")]
public class SellerController : BaseECommerceController
{
    private readonly IMapper _mapper;
    public SellerController(IUnitOfWork unitOfWork, ILogger<SellerController> logger, IMapper mapper)
        : base(unitOfWork, logger)
    {
        _mapper = mapper;
    }

    [Route("register")]
    [HttpPost]
    public async Task<SellerResponse> NewSeller(int userId)
    {
        var user = await _unitOfWork.Users.GetById(userId);
        user.Type = UserType.Customer;
        Seller seller = await _unitOfWork.Sellers.Create(new()
        {
            UserId = user.Id,
        });
        return new SellerResponse()
        {
            Id = seller.Id
        };
    }

    [Route("get")]
    [HttpGet]
    public IActionResult GetSellerInfo(int sellerId)
    {
        return Ok();
    }

    [Route("product/add")]
    [HttpPost]
    public async Task<Product> CreateProduct(int sellerId, ApiProductInfo prodInfo)
    {
        Product product = new()
        {
            Name = prodInfo.Name,
            Description = prodInfo.Description,
            SubCategoryId = prodInfo.SubcategoryId,
            Unit = prodInfo.Unit,
            Price = prodInfo.Price
        };
        var result = await _unitOfWork.Products.Create(product);

        Seller seller = await _unitOfWork.Sellers.GetById(sellerId);
        seller.Products.Add(product);
        return result;
    }

    [Route("product/edit")]
    [HttpPatch]
    public async Task<IActionResult> EditProduct(int sellerId, int productId, ApiProductInfo updatedProduct)
    {
        Product newProduct = _mapper.Map<Product>(updatedProduct);
        _unitOfWork.Products.Update(newProduct);
        return Ok();
    }

    [Route("product/disable")]
    [HttpPatch]
    public IActionResult DisableProduct(int productId)
    {
        return Ok();
    }

    [Route("is_seller")]
    [HttpGet]
    public async Task<int> IsSeller(int userId)
    {
        var result = await _unitOfWork.Sellers.FindBy(seller => seller.UserId == userId);
        if (result is not null)
            return result.Id;
        return 0;
    }

    [HttpGet]
    [Route("products")]
    public async Task<ApiSellerProductsList> GetSellerProducts(int sellerId)
    {
        List<ApiSellerProductsElement> productsElements = new List<ApiSellerProductsElement>();

        var seller = await _unitOfWork.Sellers.GetById(sellerId);
        Random r = new Random();
        foreach (var prod in seller.Products)
        {
            productsElements.Add(new ()
            {
                Count = r.Next(0,40),
                Product = new()
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Description = prod.Description,
                    Reference = prod.Reference,
                    Price = prod.Price,
                    Rating = prod.Rating,
                    Manufacturer = prod.Manufacturer,
                    Volume = prod.Volume
                }
            });
        }
        
        return new()
        {
            Elements = productsElements
        };
    }
}