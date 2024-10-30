using Films.Core.Application.Dtos.Category;

namespace Films.Core.Application.Services.Category
{
    public interface ICategoryService
    {
        void AddCategory(CategoryCreationDto category);
        Task UpdateCategory(CategoryDto categoryDto);
        Task RemoveCategory(CategoryDto categoryDto);
        Task<CategoryDto?> GetCategoryById(Guid categoryId);
        Task<CategoryDto?> GetCategoryToUpdateById(Guid categoryId);
        IQueryable<CategoryDto> GetAllCategories();
    }
}
