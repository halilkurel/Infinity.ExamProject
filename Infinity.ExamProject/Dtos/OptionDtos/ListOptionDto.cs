namespace Infinity.ExamProject.Dtos.OptionDtos
{
    public class ListOptionDto
    {
        public int OptionsId { get; set; }
        public string? OptionName { get; set; }
        public bool? correctOption { get; set; }
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }
        public string? ExamName { get; set; }
        public int ExamId { get; set; }

    }
}
