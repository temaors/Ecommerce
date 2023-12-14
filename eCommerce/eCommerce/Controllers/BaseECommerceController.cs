using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class BaseECommerceController : Controller
{
    protected readonly IUnitOfWork _unitOfWork;
    
    public BaseECommerceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
    }
}