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
    public async Task<IActionResult> GetAccount(int id)
    {
        var user = await _unitOfWork.Users.GetById(id);
        APIUser apiUser = new APIUser
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            Type = user.Type,
            Currency = user.Currency,
            Email = user.Email
        };
        ViewBag.Id = id;
        return View("Account", apiUser);
    }
}