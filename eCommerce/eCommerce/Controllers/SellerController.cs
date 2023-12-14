using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class SellerController : BaseECommerceController
{
    private readonly IUnitOfWork _unitOfWork;
    public SellerController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    //
    // [HttpPost]
    // public Task<IActionResult> RegistrationProduct(APISellersProduct product)
    // {
    //     Product newProduct = new Product()
    //     {
    //         
    //     };
    //     return new Task<IActionResult>();
    // }

    [Route("newSeller")]
    public IActionResult newSeller()
    {
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
        return View("NewSeller");
    }

    public IActionResult RegistrateSeller()
    {
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
        return View("NewSeller");
    }

    [Route("suppliers")]
    public IActionResult Suppliers()
    {
        var categories = _unitOfWork.Categories.GetAll().Select(c => c.Name).ToList();
        ViewBag.Categories = categories;
        return View("Suppliers");
    }
}