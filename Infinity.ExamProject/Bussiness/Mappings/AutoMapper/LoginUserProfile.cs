using AutoMapper;
using Infinity.ExamProject.Data.Entities;

namespace Infinity.ExamProject.Bussiness.Mappings.AutoMapper
{
    public class LoginUserProfile : Profile
    {
        public LoginUserProfile()
        {
            CreateMap<AppUser,LoginUserProfile>().ReverseMap();
        }
    }
}
