namespace Infinity.ExamProject.Data.Entities
{
    public class Options
    {
        public int OptionsId { get; set; }
        public string? OptionName { get; set; }
        public bool? correctOption { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }


	}
}
