using AutoMapper;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Dtos.ExamDtos;

namespace Infinity.ExamProject.Bussiness.Mappings.AutoMapper
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<Exam,ListExamDto>().ReverseMap();
            CreateMap<Exam,CreateExamDto>().ReverseMap();
            CreateMap<Exam,UpdateExamDto>().ReverseMap();
            CreateMap<UpdateExamDto,ListExamDto>().ReverseMap();
        }
    }
}
