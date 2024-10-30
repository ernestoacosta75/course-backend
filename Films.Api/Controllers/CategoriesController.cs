using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Dtos;
using Films.Core.Application.Dtos.Category;
using Films.Core.Application.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService genderService)
    {
        _categoryService = genderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategoriesPaginated([FromQuery] PaginationDto paginationDto)
    {
        var queryable = _categoryService.GetAllCategories();
        await HttpContext.InsertPaginationParametersInHeader(queryable);
        var genders = await queryable
            .OrderBy(x => x.Name)
            .Paginate(paginationDto)
            .ToListAsync();

        return genders;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        var categories = _categoryService.GetAllCategories();

        return categories.ToList();
    }

    [HttpGet("{categoryId:Guid}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid categoryId)
    {
        CategoryDto? category = await _categoryService.GetCategoryById(categoryId);

        if (category == null) 
        { 
            return NotFound();
        }

        return category;
    }

    [HttpPost]
    public ActionResult Post([FromBody] CategoryCreationDto categoryCreationDto)
    {
        _categoryService.AddCategory(categoryCreationDto);
        return NoContent();
    }
    
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] CategoryDto categoryDto)
    {
        var gender = await _categoryService.GetCategoryToUpdateById(id);

        if (gender == null)
        {
            return NotFound();
        }

        categoryDto.Id = id;
        await _categoryService.UpdateCategory(categoryDto);

        return NoContent();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var gender = await _categoryService.GetCategoryById(id);

        if (gender == null)
        {
            return NotFound();
        }

        await _categoryService.RemoveCategory(gender);

        return NoContent();
    }
}
