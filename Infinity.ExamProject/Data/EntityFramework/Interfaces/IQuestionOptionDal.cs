using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;

namespace Infinity.ExamProject.Data.EntityFramework.Interfaces
{
	public interface IQuestionOptionDal
	{
		Task<List<ListOptionDto>> QuestionOptionsGetAll(int id);
		Task<List<ListOptionDto>> OptionsGetAll(int id);


	}
}
