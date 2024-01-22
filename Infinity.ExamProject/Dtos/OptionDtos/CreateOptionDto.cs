namespace Infinity.ExamProject.Dtos.OptionDtos
{
    public class CreateOptionDto
    {
        public int QuestionId { get; set; }
        public string OptionName { get; set; }
        public bool CorrectOption { get; set; }
    }
}
