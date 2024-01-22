using Infinity.ExamProject.Dtos.AppUserDtos;
using Infinity.ExamProject.Dtos.ExamDtos;
using Infinity.ExamProject.Dtos.UserExamDtos;

namespace Infinity.ExamProject.Bussiness.Interfaces
{
    public interface IUserExamService
    {
        Task<ListUserExamDto> GetById(int id);
        Task<List<ListAppUserDto>> GetAllUsers();
        Task Remove(int id);
        Task Create(CreateUserExamDto createUserExam);
    }
}
