using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CategoriesController : BaseECommerceController
    {
        public CategoriesController(IUnitOfWork unitOfWork, ILogger<CategoriesController> logger) 
            : base(unitOfWork, logger)
        { }
        
        [Route("category/view")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(_unitOfWork.Categories.GetAll());
        }
        
        [Route("category/create")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(ApiCategory category)
        {
            await _unitOfWork.Categories.Create(new Category()
            {
                Name = category.Name
            });
            await _unitOfWork.Categories.Save();
            return Ok();
        }
        
        [Route("category/remove")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory()
        {
            return Ok();
        }
        [Route("subcategory/view")]
        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            return Ok(_unitOfWork.Subcategories.GetAll());
        }

        [Route("subcategory/create")]
        [HttpPost]
        public async Task<IActionResult> AddSubcategory(ApiSubcategory subcategory)
        {
            await _unitOfWork.Subcategories.Create(new SubCategory()
            {
                CategoryId = subcategory.CategoryId,
                Name = subcategory.Name
            });
            await _unitOfWork.Categories.Save();
            return Ok();
        }
        
        [Route("subcategory/remove")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcategory()
        {
            return Ok();
        }
    }
}   