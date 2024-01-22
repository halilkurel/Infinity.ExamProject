using AutoMapper;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.AppUserDtos;
using Infinity.ExamProject.Dtos.RegisterDtos;

namespace Infinity.ExamProject.Bussiness.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, CreateNewUserDto>().ReverseMap();
            CreateMap<AppUser, ListAppUserDto>().ReverseMap();
        }
    }
}
