using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestionDtos;

namespace Infinity.ExamProject.Dtos.QuestiionOptionsDtos
{
    public class UpdateQuestionOptionDto
    {
        public UpdateQuestionDto QuestionDto { get; set; }
        public List<UpdateOptionDto> Options { get; set; }
    }
}
