using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class MapController : BaseECommerceController
{
    public MapController(IUnitOfWork unitOfWork, ILogger<MapController> logger) 
        : base(unitOfWork, logger)
    { }

    [HttpGet]
    [Route("test")]
    public async Task<string> GetTest(int id)
    {
        return $"{id}";
    }
}