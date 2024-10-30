using AutoMapper;
using Films.Core.Application.Dtos.Category;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Log]
        public void AddCategory(CategoryCreationDto category)
        {
            _unitOfWork.CategoryRepository.Add(_mapper.Map<Domain.Entities.Gender>(category));
            _unitOfWork.Save();
        }

        [Log]
        public IQueryable<CategoryDto> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var categoryDtos = _mapper.ProjectTo<CategoryDto>(categories);

            return categoryDtos;
        }

        public async Task<CategoryDto?> GetCategoryById(Guid categoryId)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(categoryId);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto?> GetCategoryToUpdateById(Guid categoryId)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(categoryId);
            return _mapper.Map<CategoryDto>(categoryId); 
        }

        public async Task RemoveCategory(CategoryDto genderDto)
        {
            var categoryToDelete = _unitOfWork.CategoryRepository.GetById(genderDto.Id).Result;

            if (categoryToDelete != null)
            {
                _unitOfWork.CategoryRepository.Delete(categoryToDelete);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.GetById(categoryDto.Id);

            if (existingCategory != null)
            {
                // Update properties of the existing entity with values from the Dto
                _mapper.Map(categoryDto, existingCategory);

                // Save the updated entity
                _unitOfWork.CategoryRepository.Update(existingCategory);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
