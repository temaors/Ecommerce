using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class AuthorizationController : BaseECommerceController
{
    public AuthorizationController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}