namespace Infinity.ExamProject.Data.Entities
{
    public class UsersExams
    {
        public int UsersExamsId { get; set; }
        public int AppUserId { get; set; }
        public int ExamId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Exam Exam { get; set; }
        public AppUser AppUser { get; set; }

    }
}
