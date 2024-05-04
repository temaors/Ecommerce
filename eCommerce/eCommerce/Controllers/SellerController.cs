using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

[Route("seller")]
public class SellerController : BaseECommerceController
{
    private readonly IUnitOfWork _unitOfWork;

    public SellerController(IUnitOfWork unitOfWork, ILogger<SellerController> logger) 
        : base(unitOfWork, logger)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult newSeller()
    {
        return Ok();
    }

    [Route("get/{sellerId:int}")]
    [HttpGet]
    public IActionResult GetSeller(int sellerId)
    {
        return Ok();
    }
}