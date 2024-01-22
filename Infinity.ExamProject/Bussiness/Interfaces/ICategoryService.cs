using Infinity.ExamProject.Dtos.CategoryDtos;

namespace Infinity.ExamProject.Bussiness.Interfaces
{
    public interface ICategoryService
    {
        Task<List<ListCategoryDto>> GetAllCategoriesAsync();
        Task Create(CreateCategoryDto categoryDto);
        Task<ListCategoryDto> GetById(int id);
        Task Remove(int id);
        Task Update(UpdateCategoryDto categoryDto);
    }
}
