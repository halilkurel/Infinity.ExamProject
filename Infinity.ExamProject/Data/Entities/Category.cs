namespace Infinity.ExamProject.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Exam> Exam { get; set; }


    }
}
