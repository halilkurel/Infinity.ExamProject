using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;

namespace Infinity.ExamProject.Bussiness.Interfaces
{
    public interface IOptionService
    {
        Task<List<ListOptionDto>> GetAllAsync();
        Task<List<ListOptionDto>> GetAllQuestionOption(int id);
        Task<List<ListOptionDto>> OptionGetAll(int id);
        Task Create(CreateOptionDto OptionDto);
        Task<ListOptionDto> GetById(int id);
        Task Remove(int id);
        Task Update(UpdateOptionDto OptionDto);
    }
}
