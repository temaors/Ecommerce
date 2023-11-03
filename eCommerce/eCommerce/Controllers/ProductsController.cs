using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("viewProducts")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts() =>
        Ok(_unitOfWork.Products.GetAll());

    [Route("addProduct")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateProduct(APIProductInfo apiProductInfo)
    {
        //_unitOfWork.Products.GetAll();
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
    public async Task<IActionResult> DeleteProduct()
    {
        return Ok();
    }
    
    
}