using Infinity.ExamProject.Dtos.ExamDtos;

namespace Infinity.ExamProject.Bussiness.Interfaces
{
    public interface IExamService
    {
        Task<List<ListExamDto>> GetAllCategoriesAsync();
        Task Create(CreateExamDto ExamDto);
        Task<ListExamDto> GetById(int id);
        Task Remove(int id);
        Task Update(UpdateExamDto ExamDto);
    }
}
