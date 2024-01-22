namespace Infinity.ExamProject.Dtos.OptionDtos
{
    public class UpdateOptionDto
    {
        public int OptionsId { get; set; }
        public string? OptionName { get; set; }
        public bool correctOption { get; set; }
        public int QuestionId { get; set; }
    }
}
