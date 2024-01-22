using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.AppUserDtos;
using Infinity.ExamProject.Dtos.ExamDtos;

namespace Infinity.ExamProject.Dtos.UserExamDtos
{
    public class ListUserExamDto
    {
        public int UsersExamsId { get; set; }
        public ListAppUserDto ListAppUserDto { get; set; }
        public List<ListExamDto> ListExamDtos { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}