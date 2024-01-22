using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Bussiness.Services;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Dtos.UserExamDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infinity.ExamProject.Controllers
{
    public class ExamAssignmentController : Controller
    {
        private readonly IUserExamService _userExamService;
        private readonly IUserExamDal _userExamDal;
        private readonly IExamService _examService;
        

        public ExamAssignmentController(IUserExamService userExamService, IUserExamDal userExamDal, IExamService examService)
        {
            _userExamService = userExamService;
            _userExamDal = userExamDal;
            _examService = examService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _userExamService.GetAllUsers();
            return View(list);
        }

        //Burada kullanıcıya ait sınavalar listelenecek
        public async Task<IActionResult> GetAllUsers(int id)
        {
            ViewBag.Id = id;    
            var list = await _userExamDal.listUserExamDtos(id);
            return View(list);
        }

        public async Task<IActionResult> DeleteUserExam(int id)
        {
            var deletendata = await _userExamService.GetById(id);
            await _userExamService.Remove(id);
            return RedirectToAction("GetAllUsers", "ExamAssignment");
        }
        [HttpGet]
        public async Task<IActionResult> CreateExam(int id)
        {
            var listExam = await _examService.GetAllCategoriesAsync();
            ViewBag.Exams = listExam;
            ViewBag.AppUserId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam(CreateUserExamDto createExamDto)
        {
            await _userExamService.Create(createExamDto);
            return RedirectToAction("GetAllUsers", "ExamAssignment", new {id =createExamDto.AppUserId});
        }


    }
}
