using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

[Produces("application/json")]
[ApiController]
public class BaseECommerceController : Controller
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly ILogger logger;
    public BaseECommerceController(IUnitOfWork unitOfWork, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        this.logger = logger;
    }
}