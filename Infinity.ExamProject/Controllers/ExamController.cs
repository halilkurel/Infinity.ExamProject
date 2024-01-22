using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Bussiness.Services;
using Infinity.ExamProject.Dtos.CategoryDtos;
using Infinity.ExamProject.Dtos.ExamDtos;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.ExamProject.Controllers
{
    public class ExamController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExamService _examService;
        private readonly ICategoryService _categoryService;

        public ExamController(IExamService examService, ICategoryService categoryService, IMapper mapper)
        {
            _examService = examService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _examService.GetAllCategoriesAsync();
            return View(list);
        }

        public async Task<IActionResult> DeleteExam(int id)
        {
            await _examService.Remove(id);
            return RedirectToAction("Index", "Exam");
        }

        [HttpGet]
        public async Task<IActionResult> CreateExam()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam(CreateExamDto createExam)
        {
            await _examService.Create(createExam);
            return RedirectToAction("Index", "Exam");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateExam(int id)
        {
            var exam = await _examService.GetById(id);

            var data = _mapper.Map<UpdateExamDto>(exam);

            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExam(UpdateExamDto updateExamDto)
        {

            await _examService.Update(updateExamDto);
            return RedirectToAction("Index", "Exam");


        }

    }
}
