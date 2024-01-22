using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.ExamDtos;
using Infinity.ExamProject.Dtos.UserExamDtos;

namespace Infinity.ExamProject.Data.EntityFramework.Interfaces
{
    public interface IUserExamDal
    {
        Task<List<ListUserExamDto>> listUserExamDtos(int id);
    }
}
