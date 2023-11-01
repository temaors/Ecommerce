using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
    
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public async Task<IActionResult> AddCategory()
        {
            return Ok();
        }
        
        [Route("addSubcategory")]
        [HttpPost]
        public async Task<IActionResult> AddSubcategory()
        {
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