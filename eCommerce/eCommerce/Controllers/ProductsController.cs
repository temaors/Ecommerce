using eCommerce.APIObjects;
using eCommerce.Database.UnitOfWork;
using eCommerce.Validators;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> GetProducts()
    {
        
        return Ok();
    }
    
}