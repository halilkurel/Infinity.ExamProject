using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestionDtos;

namespace Infinity.ExamProject.Dtos.QuestiionOptionsDtos
{
    public class CreateQuestionOptionsDto
    {
        public CreateQuestionDto QuestionDto { get; set; }
        public List<CreateOptionDto> OptionsDto { get; set; }
    }
}
