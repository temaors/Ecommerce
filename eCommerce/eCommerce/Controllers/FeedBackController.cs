using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

public class FeedBackController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public FeedBackController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("addFeedback")]
    public async Task<IActionResult> AddFeedBack(APIFeedback feedback)
    {
        FeedBack feedBack = new FeedBack()
        {
            Text = feedback.FeedbackText,
            ProductId = feedback.ProductId,
            Mark = feedback.Mark
        };
        await _unitOfWork.FeedBacks.Create(feedBack);
        return Ok();
    }

    [HttpGet]
    [Route("getFeedbacks")]
    public async Task<IActionResult> GetFeedbacksByProductId(int productId) => 
        Ok(await _unitOfWork.FeedBacks.FindBy(feedBack => feedBack.ProductId == productId));
}