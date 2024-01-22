using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Data.EntityFramework.Services;
using Infinity.ExamProject.Data.UnitOfWork;
using Infinity.ExamProject.Dtos.CategoryDtos;
using Infinity.ExamProject.Dtos.ExamDtos;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Bussiness.Services
{
    public class ExamService: IExamService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IExamDal _examdal;

		public ExamService(IUow uow, IMapper mapper, IExamDal examdal)
		{
			_uow = uow;
			_mapper = mapper;
			_examdal = examdal;
		}

		public async Task Create(CreateExamDto ExamDto)
        {
            var data = _mapper.Map<Exam>(ExamDto);
            await _uow.GetRepositories<Exam>().Create(data);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<ListExamDto>> GetAllCategoriesAsync()
        {
            return await _examdal.GetAllExam();
        }

        public async Task<ListExamDto> GetById(int id)
        {
            var data = await _uow.GetRepositories<Exam>().GetById(id);
            return _mapper.Map<ListExamDto>(data);
        }

        public async Task Remove(int id)
        {
            var data = await _uow.GetRepositories<Exam>().GetById(id);
            _uow.GetRepositories<Exam>().Remove(data);
            await _uow.SaveChangesAsync();
        }

        public async Task Update(UpdateExamDto ExamDto)
        {
            var updatedEntity = await _uow.GetRepositories<Exam>().GetById(ExamDto.ExamId);
            if (updatedEntity != null)
            {
                _uow.GetRepositories<Exam>().Update(_mapper.Map<Exam>(ExamDto), updatedEntity);
                await _uow.SaveChangesAsync();

            }
        }
    }
}
