using eCommerce.APIObjects;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class AuthorizationController : BaseECommerceController
{
    public AuthorizationController(IUnitOfWork unitOfWork, ILogger<AuthorizationController> logger) :
        base(unitOfWork, logger)
    { }
    
    [Route("sign_in")]
    [HttpGet]
    public IActionResult SignIn(ApiCredentials credentials)
    {
        int? id = _unitOfWork.Users.FindBy(user => user.Email.Equals(credentials.Email)).Id;
        if (id is not null)//todo: FindBy works incorrect
            return Ok(new SignedUserResponse
                {
                    Id = id.Value
                });
        return BadRequest();
    }

    [Route("sign_up")]
    [HttpPost]
    public IActionResult SignUp()
    {
        return Ok();
    }
}