using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestionDtos;

namespace Infinity.ExamProject.Dtos.QuestiionOptionsDtos
{
    public class ListQuestionOptionsDto
    {
        public ListQuestionDto QuestionDto { get; set; }
        public List<ListOptionDto> OptionDtos { get; set; }
    }
}
