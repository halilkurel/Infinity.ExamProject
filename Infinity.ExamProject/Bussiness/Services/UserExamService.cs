using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Data.Context;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Data.UnitOfWork;
using Infinity.ExamProject.Dtos.AppUserDtos;
using Infinity.ExamProject.Dtos.ExamDtos;
using Infinity.ExamProject.Dtos.UserExamDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Bussiness.Services
{
	public class UserExamService : IUserExamService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IUow _uow;

        public UserExamService(UserManager<AppUser> userManager, IMapper mapper, IUow uow)
        {
            _userManager = userManager;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<ListAppUserDto>> GetAllUsers()
		{
			var users = await _userManager.GetUsersInRoleAsync("Student");
			return _mapper.Map<List<ListAppUserDto>>(users);
		}

        public async Task<ListUserExamDto> GetById(int id)
        {
            var data = await _uow.GetRepositories<UsersExams>().GetById(id);
            return _mapper.Map<ListUserExamDto>(data);
        }

        public async Task Remove(int id)
        {
            var data = await _uow.GetRepositories<UsersExams>().GetById(id);
            _uow.GetRepositories<UsersExams>().Remove(data);
            await _uow.SaveChangesAsync();
        }

        public async Task Create(CreateUserExamDto createUserExam)
        {
            await _uow.GetRepositories<UsersExams>().Create(_mapper.Map<UsersExams>(createUserExam));
            await _uow.SaveChangesAsync();

        }
    }
}
