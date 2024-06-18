using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using eCommerce.Infrastructure.Types.Enums;
using eCommerce.Validators;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class AuthorizationController : BaseECommerceController
{
    private CredentialsValidator<AuthorizationController> _validator = new();
    public AuthorizationController(IUnitOfWork unitOfWork, ILogger<AuthorizationController> logger) :
        base(unitOfWork, logger)
    { }
    
    [Route("sign_in")]
    [HttpPost]
    public async Task<UserResponse> SignIn(ApiCredentials credentials)
    {
         if (_validator.IsCredintialsValid(credentials))
        {
            User user = await _unitOfWork.Users.FindBy(user => user.Email.Equals(credentials.Email)) ??
                throw new BadHttpRequestException("Login or password are incorrect");
            
            return new()
            {
                Id = user.Id
            };
        }

        throw new BadHttpRequestException("Login or password are incorrect");
    }

    [Route("sign_up")]
    [HttpPost]
    public async Task<UserResponse> SignUp(SignUpCredentials credentials)
    {
        if (_validator.IsCredintialsValid(credentials))
        {
            User founduser = await _unitOfWork.Users.FindBy(user => user.Email.Equals(credentials.Email));
            
            if (founduser is null)
            {
                User newUser = await _unitOfWork.Users.Create(new()
                {
                    Email = credentials.Email,
                    Password = credentials.Password,
                    FirstName = credentials.FirstName,
                    Type = UserType.Customer,
                    Currency = Currency.Byn
                });
                await _unitOfWork.Carts.Create(new()
                {
                    UserId = newUser.Id,
                    Products = new()
                });
                await _unitOfWork.UserFavourites.Create(new()
                {
                    UserId = newUser.Id,
                    Products = new()
                });
                return new()
                {
                    Id = newUser.Id
                };
            }
            else
            {
                throw new BadHttpRequestException("Unable to sign up. This email has already been registered");
            }
        }

        throw new BadHttpRequestException("Unable to sign up");
    }
}