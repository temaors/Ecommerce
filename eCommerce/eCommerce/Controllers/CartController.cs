using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class CartController : BaseECommerceController
{
    public CartController(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    [HttpPatch]
    public async Task<IActionResult> AddToCart()
    {
        return Ok();
    }
    [HttpPost]
    [Route("addCart")]
    public async Task<IActionResult> CreateCart(int userId) =>
    Ok(await _unitOfWork.Carts.Create(new Cart()
    {
        UserId = userId
    }));

    [HttpGet]
    [Route("viewCart")]
    public async Task<IActionResult> GetCart(int userId) => 
        Ok(await _unitOfWork.Carts.FindBy(cart => cart.UserId == userId));

    [HttpPatch]
    [Route("clearCart")]
    public async Task<IActionResult> ClearCart(int userId)
    {
        Cart cart = await _unitOfWork.Carts.FindBy(cart => cart.UserId == userId);
        cart.Products = new List<Product>();
        return Ok(_unitOfWork.Carts.Update(cart));
    }

    [HttpGet]
    [Route("payPurchase")]
    public async Task<IActionResult> PayPurchase(int cartId)
    {
        bool paymentSuccessfull = true;
        if (paymentSuccessfull)
            return Ok();
        return BadRequest();
    }
}