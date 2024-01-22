using Infinity.ExamProject.Dtos.ExamDtos;

namespace Infinity.ExamProject.Data.EntityFramework.Interfaces
{
	public interface IExamDal
	{
		Task<List<ListExamDto>> GetAllExam();
		Task<CreateExamDto> CreateExamAsync(CreateExamDto createExamDto);
		
	}
}
