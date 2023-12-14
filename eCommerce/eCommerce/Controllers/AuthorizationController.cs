using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class AuthorizationController : BaseECommerceController
{
    public AuthorizationController(IUnitOfWork unitOfWork) : base(unitOfWork)
    { }
    
    [Route("signIn")]
    public IActionResult SignIn(int? id)
    {
        if (id == null)
            return View("SignIn");
        else
            return RedirectToAction("GetAccount", "User", new {id});
    }

    [Route("signUp")]
    public IActionResult SignUp()
    {
        return View("SignUp");
    }

    
    public async Task<IActionResult> LogIn(APICredentials creds)
    {
        User newUser = new User()
        {
            Email = creds.Email,
            Password = creds.Password
        };
        var allUsers = _unitOfWork.Users.GetAll();
        foreach (var us in allUsers)
        {
            if(us.Email == creds.Email && us.Password == creds.Password)
                return RedirectToAction("GetProducts", "Products", new { id = us.Id});
        }

        return SignIn(null);
    }
}