using AutoMapper;
using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class ProductsController : BaseECommerceController
{
    private readonly IMapper _mapper;
    
    public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductsController> logger) 
        : base(unitOfWork, logger)
    {
        _mapper = mapper;
    }
    [Route("view")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts(int? id)
    {
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
        if (id == null)
        {
            return RedirectToAction("ViewProducts");
        }
        List<ApiProductInfo> products = new List<ApiProductInfo>();

        foreach (var prod in _unitOfWork.Products.GetAll())
        {
            products.Add(new ApiProductInfo()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Rating = Math.Round(prod.FeedBacks?.Average(p => p.Mark) ??  0.0, 1)
            });
        }

        User? dbUser = await _unitOfWork.Users.GetById(id.Value);
        
        ApiUser apiUser = _mapper.Map<ApiUser>(dbUser);
        UserProductViewModel viewModel = new UserProductViewModel()
        {
            UserProducts = products,
            User = apiUser
        };
        ViewBag.Id = dbUser.Id;
        return View("ViewProducts", viewModel);
    }
    
    [HttpGet]
    public async Task<IActionResult> ViewProducts()
    {
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
        List<ApiProductInfo> products = new List<ApiProductInfo>();

        foreach (var prod in _unitOfWork.Products.GetAll())
        {
            products.Add(new ApiProductInfo()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Reference = prod.Reference,
                Price = prod.Price,
                Rating = prod.Rating
            });
        }
        UserProductViewModel viewModel = new UserProductViewModel()
        {
            UserProducts = products
        };
        return View("Index", viewModel);
    }

    [Route("addProduct")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateProduct(ApiProductInfo apiProductInfo)
    {
        Product product = new Product()
        {
            Name = apiProductInfo.Name,
            Description = apiProductInfo.Description,
            Price = apiProductInfo.Price,
            UnitId = apiProductInfo.UnitId,
            SubCategoryId = apiProductInfo.SubcategoryId
        };
        await _unitOfWork.Products.Create(product);
        await _unitOfWork.Categories.Save();
        return Ok();
    }

    [Route("deleteProduct")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        await _unitOfWork.Products.Delete(productId);
        await _unitOfWork.Products.Save();
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> ViewProductDetails(int id)
    {
        Product product = await _unitOfWork.Products.GetById(id);
        ApiProductInfo productResult = _mapper.Map<ApiProductInfo>(product);
        return View("ProductInfo", productResult);
    }
}