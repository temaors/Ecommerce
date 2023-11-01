using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using ProductInfo = eCommerce.APIObjects.ProductInfo;

namespace eCommerce.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("view")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts() =>
        Ok(_unitOfWork.Products.GetAll());

    [Route("add")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateProduct(ProductInfo productInfo)
    {
        //_unitOfWork.Products.GetAll();
        Product product = new Product()
        {
            Name = productInfo.Name,
            Description = productInfo.Description,
            Price = productInfo.Price,
            UnitId = productInfo.UnitId,
            
        };
        //productInfo => Product
        return Ok();
    }
    [Route("viewCategory")]
    public async Task<IActionResult> ViewCategory()
    {
        return Ok();
    }
}