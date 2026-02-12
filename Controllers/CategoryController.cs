using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourses.DTO_s.Categories;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) { 
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var Categories = await _categoryRepository.GetAllAsync();
            var CategoriesDTO = Categories.Select(c => c.toCategoryDTO()).ToList(); 

            return Ok(CategoriesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("The Category is not found");
            }
            return Ok(category.toCategoryDTO());
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.CreateAsync(categoryDTO);

            if (category == null)
            {
                return StatusCode(500, "Failed to Create: All Ready Exists");
            }
            return Ok(category.toCategoryDTO());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditCategory([FromRoute] int id,[FromBody] EditCategoryDTO categorydto)
        {
            var category = await _categoryRepository.EditAsync(id, categorydto);

            if(category == null)
            {
                return NotFound("Category Couldnt be found");
            }
            return Ok(category.toCategoryDTO());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await _categoryRepository.DeleteAsync(id);
            if(category == null)
            {
                return NotFound("This Category Doesnt Exist");
            }

            return Ok(category.toCategoryDTO());
        }
    }
}
