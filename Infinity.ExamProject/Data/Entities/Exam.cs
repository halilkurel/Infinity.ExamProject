namespace Infinity.ExamProject.Data.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string? ExamName { get; set; }
        public int? CategoryId { get; set; }
        public Category Categories { get; set; }
        public List<Question> Questions { get; set; }
        public List<UsersExams> UsersExams { get; set; }


    }
}
