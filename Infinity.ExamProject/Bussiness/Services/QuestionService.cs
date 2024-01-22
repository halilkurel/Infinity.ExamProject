using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.UnitOfWork;
using Infinity.ExamProject.Dtos.CategoryDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;
using Infinity.ExamProject.Dtos.QuestionDtos;

namespace Infinity.ExamProject.Bussiness.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public QuestionService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(CreateQuestionDto QuestionDto)
        {
            var data = _mapper.Map<Question>(QuestionDto);
            await _uow.GetRepositories<Question>().Create(data);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<ListQuestionDto>> GetAllQuestionAsync()
        {
            var list = await _uow.GetRepositories<Question>().GetAllAsync();
            return _mapper.Map<List<ListQuestionDto>>(list);
        }

        public async Task<ListQuestionDto> GetById(int id)
        {
            var data = await _uow.GetRepositories<Question>().GetById(id);
            return _mapper.Map<ListQuestionDto>(data);
        }

        public async Task Remove(int id)
        {
            var data = await _uow.GetRepositories<Question>().GetById(id);
            _uow.GetRepositories<Question>().Remove(data);
            await _uow.SaveChangesAsync();
        }

        public async Task Update(UpdateQuestionDto QuestionDto)
        {
            var updatedEntity = await _uow.GetRepositories<Question>().GetById(QuestionDto.QuestionId);
            if (updatedEntity != null)
            {
                _uow.GetRepositories<Question>().Update(_mapper.Map<Question>(QuestionDto), updatedEntity);
                await _uow.SaveChangesAsync();

            }
        }
    }
}
