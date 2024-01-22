using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;
using Infinity.ExamProject.Dtos.QuestionDtos;

namespace Infinity.ExamProject.Bussiness.Interfaces
{
    public interface IQuestionService
    {
        Task<List<ListQuestionDto>> GetAllQuestionAsync();
        Task Create(CreateQuestionDto QuestionDto);
        Task<ListQuestionDto> GetById(int id);
        Task Remove(int id);
        Task Update(UpdateQuestionDto QuestionDto);
    }
}
