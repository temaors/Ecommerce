using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using eCommerce.APIObjects;

namespace eCommerce.Controllers;

[Route("cart")]
public class CartController : BaseECommerceController
{
    public CartController(IUnitOfWork unitOfWork, ILogger<CartController> logger) 
        : base(unitOfWork, logger)
    { }

    [HttpGet]
    public async Task<ApiCart> GetProductsInCart(int cartId)
    {
        Cart cart = await _unitOfWork.Carts.GetById(cartId);
        ApiCart result =  new()
        {
            UserId = cart.UserId,
            Products = new()
        };
            
        if(cart.Products is not null)
            foreach (var item in cart.Products)
            {
                result.Products.Add(new ()
                {
                    Product = item.Product, Count = item.Count
                });
            }
        
        return result;
    }
    
    [HttpPatch]
    [Route("add_product")]
    public async Task<IActionResult> AddToCart(int cartId, int productId)
    {
        Cart cart = await _unitOfWork.Carts.GetById(cartId) ?? throw new NullReferenceException();
        Product productToAdd = await _unitOfWork.Products.GetById(productId);

        if (cart.Products is null)
            cart.Products = new();
        cart.Products.Add(new ()
        {
            Product = productToAdd,
            Count = 1
        });
        _unitOfWork.Carts.Update(cart);
        return Ok();
    }

    [HttpGet]
    [Route("getId")]
    public async Task<ApiCartResponse> GetCart(int userId)
    {
        Cart cart = await _unitOfWork.Carts.FindBy(cart => cart.UserId == userId) ?? throw new NullReferenceException("Unable to find Cart");

        return new()
        {
            Id = cart.Id
        };
    }

    [HttpPatch]
    [Route("clear")]
    public async Task<Cart> ClearCart(int cartId)
    {
        Cart cart = await _unitOfWork.Carts.GetById(cartId) ?? throw new NullReferenceException();
        cart.Products = null;
        cart = _unitOfWork.Carts.Update(cart);
        return cart;
    }

    [HttpGet]
    [Route("is_in_cart")]
    public async Task<int> IsProductInCart(int cartId, int productId)
    {
        Cart cart = await _unitOfWork.Carts.GetById(cartId) ?? throw new NullReferenceException();
        var result = cart.Products.FirstOrDefault(p => p.Product.Id == productId);
        if (result is null)
            return 0;
        return result.Count;
    }
    
    [HttpPatch]
    [Route("change_product_quantity")]
    public async Task<IActionResult> ChangeProductQuantity(int cartId, int productId, int count)
    {
        Cart cart = await _unitOfWork.Carts.GetById(cartId) ?? throw new NullReferenceException();
        CartElement result = cart.Products.FirstOrDefault(p => p.Product.Id == productId);
        result.Count = count;
        _unitOfWork.Carts.Update(cart);
        return Ok();
    }
    
    [HttpPatch]
    [Route("delete_product")]
    public async Task<IActionResult> DeleteProductFromCart(int cartId, int productId)
    {
        Cart cart = await _unitOfWork.Carts.GetById(cartId) ?? throw new NullReferenceException();
        await _unitOfWork.CartElements.Delete(cart.Products.FirstOrDefault(p => p.Product.Id == productId).Id);
        return Ok();
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