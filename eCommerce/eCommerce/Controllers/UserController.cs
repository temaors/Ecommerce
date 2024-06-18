using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class UserController : BaseECommerceController
{
    public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger) 
        : base(unitOfWork, logger)
    { }

    [Route("account")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiUser))]
    [HttpGet]
    public async Task<IActionResult> GetAccount(int userId)
    {
        var user = await _unitOfWork.Users.GetById(userId);
        //var address = await _unitOfWork.DeliveryPoints.FindBy(address => address.UserId == userId);
        //todo create table usersPointOfDeliveries (many to many)
        ApiUser apiUser = new ApiUser
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Type = user.Type,
            Currency = user.Currency,
            Email = user.Email,
            Password = user.Password
        };
        return Ok(apiUser);
    }

    [Route("update_user")]
    [HttpPatch]
    public async Task<IActionResult> UpdateData(ApiUser apiUser)
    {
        User user = await _unitOfWork.Users.GetById(apiUser.Id);
        user.Currency = apiUser.Currency;
        user.Email = apiUser.Email;
        user.FirstName = apiUser.FirstName;
        user.LastName = apiUser.LastName;
        user.MiddleName = apiUser.MiddleName;
        user.Password = apiUser.Password;
        var result = _unitOfWork.Users.Update(user);
        return Ok(user);
    }
} 