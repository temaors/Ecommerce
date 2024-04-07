using eCommerce.APIObjects;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class UserController : BaseECommerceController
{
    public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    [Route("account")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIUser))]
    public async Task<IActionResult> GetAccount(int userId)
    {
        var user = await _unitOfWork.Users.GetById(userId);
        //var address = await _unitOfWork.DeliveryPoints.FindBy(address => address.UserId == userId);
        //todo create table usersPointOfDeliveries (many to many)
        APIUser apiUser = new APIUser
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Type = user.Type,
            Currency = user.Currency,
            Email = user.Email
        };
        
        
        return Ok(apiUser);
    }
} 