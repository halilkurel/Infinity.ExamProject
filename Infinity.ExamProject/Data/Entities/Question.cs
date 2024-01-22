namespace Infinity.ExamProject.Data.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }
        public int? ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<Options> Options { get; set; }



    }
}
