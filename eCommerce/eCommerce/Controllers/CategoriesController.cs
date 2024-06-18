using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;
using eCommerce.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class CategoriesController : BaseECommerceController
    {
        public CategoriesController(IUnitOfWork unitOfWork, ILogger<CategoriesController> logger) 
            : base(unitOfWork, logger)
        { }

        [Route("category/all")]
        [HttpGet]
        public async Task<AllCategoriesResponse> GetCategories()
        {
            AllCategoriesResponse response = new AllCategoriesResponse()
            {
                Categories = new()
            };
            var categories = await _unitOfWork.Categories.GetAll().ToArrayAsync();
            foreach (Category c in categories)
            {
                Dictionary<int, string> dict = new Dictionary<int, string>();
                if (c.SubCategories is not null)
                {
                    foreach (var subCategory in c.SubCategories)
                    {
                        dict[subCategory.Id] = subCategory.Name ?? string.Empty;
                    }
                }

                response.Categories.Add(new()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Subcategories = dict
                });
            }
            return response;
        }

        [Route("category/create")]
        [HttpPost]
        public async Task<CategoryResponse> AddCategory(ApiCategory category)
        {
            var result = await _unitOfWork.Categories.Create(new Category()
            {
                Name = category.Name
            });
            return new()
            {
                Id = result.Id
            };
        }
        
        [Route("category/remove")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _unitOfWork.Categories.Delete(categoryId);
            return Ok();
        }
        
        [Route("subcategory/view")]
        [HttpGet]
        public IActionResult GetSubCategories() =>
             Ok(_unitOfWork.Subcategories.GetAll());

        [Route("subcategory/create")]
        [HttpPost]
        public async Task<IActionResult> AddSubcategory(ApiSubcategory subcategory)
        {
            await _unitOfWork.Subcategories.Create(new SubCategory()
            {
                CategoryId = subcategory.CategoryId,
                Name = subcategory.Name
            });
            return Ok();
        }
        
        [Route("subcategory/remove")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcategory(int subcategoryId)
        {
            await _unitOfWork.Subcategories.Delete(subcategoryId);
            return Ok();
        }
    }
}   