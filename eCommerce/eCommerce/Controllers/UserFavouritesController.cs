using eCommerce.APIObjects;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class UserFavouritesController : BaseECommerceController
{
    public UserFavouritesController(IUnitOfWork unitOfWork, ILogger<UserFavouritesController> logger) 
        : base(unitOfWork, logger)
    { }
    
    [Route("user_favourites")]
    [HttpGet]
    public async Task<UserFavouritesResponse> GetUserFavourites(int userId)
    {
        var result  = await _unitOfWork.UserFavourites.FindBy(user => user.UserId == userId);
        return new()
        {
            Id = result.Id
        };
    }
    
    [Route("all_user_favourites")]
    [HttpGet]
    public async Task<List<int>> GetAllUserFavourites(int userId)
    {
        var result  = await _unitOfWork.UserFavourites.FindBy(user => user.UserId == userId);
        return result.Products;
    }

    [Route("delete_user_favourite")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id, int productId)
    {
        var prods = await _unitOfWork.UserFavourites.GetById(id);
        prods.Products.Remove(productId);
        _unitOfWork.UserFavourites.Update(prods);
        return Ok();
    }
}