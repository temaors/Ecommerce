using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CategoriesController : ControllerBase
    {
        [Route("viewCategory")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok();
        }
        
        [Route("viewSubcategory")]
        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            return Ok();
        }
        
        [Route("addCategory")]
        [HttpPost]
        public async Task<IActionResult> AddCategory()
        {
            return Ok();
        }
        
        [Route("addSubcategory")]
        [HttpPost]
        public async Task<IActionResult> AddSubCategory()
        {
            return Ok();
        }
        
        [Route("deleteCategory")]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory()
        {
            return Ok();
        }
        
        [Route("deleteSubcategory")]
        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory()
        {
            return Ok();
        }
    }
}