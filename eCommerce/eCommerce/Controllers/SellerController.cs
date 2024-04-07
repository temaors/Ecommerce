using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class SellerController : BaseECommerceController
{
    private readonly IUnitOfWork _unitOfWork;

    public SellerController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("newSeller")]
    public IActionResult newSeller()
    {
        return Ok();
    }

}