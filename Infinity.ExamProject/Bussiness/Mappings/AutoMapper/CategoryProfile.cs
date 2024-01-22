using AutoMapper;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.CategoryDtos;

namespace Infinity.ExamProject.Bussiness.Mappings.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,ListCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryDto,ListCategoryDto>().ReverseMap();
        }
    }
}
