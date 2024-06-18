using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers;

[Route("feedback")]
public class FeedBackController : BaseECommerceController
{
    public FeedBackController(IUnitOfWork unitOfWork, ILogger<FeedBackController> logger) 
        : base(unitOfWork, logger)
    { }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> AddFeedBack(ApiFeedback feedback)
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
    [Route("get")]
    public async Task<IActionResult> GetFeedbacksByProductId(int productId) => 
        Ok(await _unitOfWork.FeedBacks.FindBy(feedBack => feedBack.ProductId == productId));
}