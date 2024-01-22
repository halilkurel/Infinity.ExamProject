using AutoMapper;
using Azure;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.UnitOfWork;
using Infinity.ExamProject.Dtos.CategoryDtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infinity.ExamProject.Bussiness.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CategoryService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(CreateCategoryDto categoryDto)
        {
            var data = _mapper.Map<Category>(categoryDto);
            await _uow.GetRepositories<Category>().Create(data);
            await _uow.SaveChangesAsync();
        }

        public async Task<List<ListCategoryDto>> GetAllCategoriesAsync()
        {
            var list = await _uow.GetRepositories<Category>().GetAllAsync();
            return _mapper.Map<List<ListCategoryDto>>(list);
        }

        public async Task<ListCategoryDto> GetById(int id)
        {
            var data = await _uow.GetRepositories<Category>().GetById(id);
            return _mapper.Map<ListCategoryDto>(data);
        }

        public async Task Remove(int id)
        {
            var data = await _uow.GetRepositories<Category>().GetById(id);
            _uow.GetRepositories<Category>().Remove(data);
            await _uow.SaveChangesAsync();
        }

        public async Task Update(UpdateCategoryDto categoryDto)
        {
            var updatedEntity = await _uow.GetRepositories<Category>().GetById(categoryDto.CategoryId);

            
            if (updatedEntity != null)
            {
                _uow.GetRepositories<Category>().Update(_mapper.Map<Category>(categoryDto), updatedEntity);
                await _uow.SaveChangesAsync();
                
            }
        }
    }
}
