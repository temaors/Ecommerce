using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CategoriesController : BaseECommerceController
    {
    
        public CategoriesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        [Route("viewCategory")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(_unitOfWork.Categories.GetAll());
        }
        
        [Route("viewSubcategory")]
        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            return Ok(_unitOfWork.Subcategories.GetAll());
        }
        
        [Route("addCategory")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(APICategory category)
        {
            await _unitOfWork.Categories.Create(new Category()
            {
                Name = category.Name
            });
            await _unitOfWork.Categories.Save();
            return Ok();
        }
        
        [Route("addSubcategory")]
        [HttpPost]
        public async Task<IActionResult> AddSubcategory(APISubcategory subcategory)
        {
            await _unitOfWork.Subcategories.Create(new SubCategory()
            {
                CategoryId = subcategory.CategoryId,
                Name = subcategory.Name
            });
            await _unitOfWork.Categories.Save();
            return Ok();
        }
        
        [Route("deleteCategory")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory()
        {
            return Ok();
        }
        
        [Route("deleteSubcategory")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcategory()
        {
            return Ok();
        }
    }
}