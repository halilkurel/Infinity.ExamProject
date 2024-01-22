using Infinity.ExamProject.Data.Entities;

namespace Infinity.ExamProject.Dtos.UserExamDtos
{
    public class CreateUserExamDto
    {
        public int AppUserId { get; set; }
        public int ExamId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
