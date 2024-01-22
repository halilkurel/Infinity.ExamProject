using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.ExamProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _categoryService.GetAllCategoriesAsync();
            return View(list);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var entity = await _categoryService.GetById(id);
            var updateEntity = _mapper.Map<UpdateCategoryDto>(entity);
            return View(updateEntity);
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategory)
        {
            await _categoryService.Update(updateCategory);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategory)
        {
            await _categoryService.Create(createCategory);
            return RedirectToAction("Index", "Category");
        }



    }
}
