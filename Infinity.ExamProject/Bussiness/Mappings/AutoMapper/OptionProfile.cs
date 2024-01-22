using AutoMapper;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;

namespace Infinity.ExamProject.Bussiness.Mappings.AutoMapper
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<Options,ListOptionDto>().ReverseMap();
            CreateMap<Options,CreateOptionDto>().ReverseMap();
            CreateMap<Options,UpdateOptionDto>().ReverseMap();
            CreateMap<UpdateOptionDto,ListOptionDto>().ReverseMap();

            CreateMap<Options,CreateQuestionOptionsDto>().ReverseMap();
            CreateMap<Options,UpdateQuestionOptionDto>().ReverseMap();
            CreateMap<Options,ListQuestionOptionsDto>().ReverseMap();
            CreateMap<CreateOptionDto,ListQuestionOptionsDto>().ReverseMap();
        }
    }
}
