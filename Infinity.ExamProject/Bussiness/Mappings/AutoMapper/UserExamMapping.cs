using AutoMapper;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.UserExamDtos;

namespace Infinity.ExamProject.Bussiness.Mappings.AutoMapper
{
    public class UserExamMapping : Profile
    {
        public UserExamMapping()
        {
            CreateMap<UsersExams,ListUserExamDto>().ReverseMap();
            CreateMap<UsersExams,CreateUserExamDto>().ReverseMap();
            CreateMap<UsersExams,UpdateUserExamDto>().ReverseMap();
            CreateMap<UpdateUserExamDto,ListUserExamDto>().ReverseMap();
        }
    }
}
