using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Data.UnitOfWork;
using Infinity.ExamProject.Dtos.CategoryDtos;
using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;
using Microsoft.CodeAnalysis.Options;

namespace Infinity.ExamProject.Bussiness.Services
{
    public class OptionService : IOptionService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IQuestionOptionDal _questionOptionDal;

		public OptionService(IUow uow, IMapper mapper, IQuestionOptionDal questionOptionDal)
		{
			_uow = uow;
			_mapper = mapper;
			_questionOptionDal = questionOptionDal;
		}

		public async Task Create(CreateOptionDto OptionDto)
        {
            var data = _mapper.Map<Options>(OptionDto);
            await _uow.GetRepositories<Options>().Create(data);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<ListOptionDto>> GetAllAsync()
        {
            var list = await _uow.GetRepositories<Options>().GetAllAsync();

            return _mapper.Map<List<ListOptionDto>>(list);
        }


        public Task<List<ListOptionDto>> GetAllQuestionOption(int id)
		{
            return _questionOptionDal.QuestionOptionsGetAll(id);
		}

		public async Task<ListOptionDto> GetById(int id)
        {
            var data = await _uow.GetRepositories<Options>().GetById(id);
            return _mapper.Map<ListOptionDto>(data);
        }

        public async Task<List<ListOptionDto>> OptionGetAll(int id)
        {
            var list = await _questionOptionDal.OptionsGetAll(id);
            return list ;
        }

        public async Task Remove(int id)
        {
            var data = await _uow.GetRepositories<Options>().GetById(id);
            _uow.GetRepositories<Options>().Remove(data);
            await _uow.SaveChangesAsync();
        }

        public async Task Update(UpdateOptionDto OptionDto)
        {
            var updatedEntity = await _uow.GetRepositories<Options>().GetById(OptionDto.OptionsId);
            if (updatedEntity != null)
            {
                _uow.GetRepositories<Options>().Update(_mapper.Map<Options>(OptionDto), updatedEntity);
                await _uow.SaveChangesAsync();

            }
        }
    }
}
