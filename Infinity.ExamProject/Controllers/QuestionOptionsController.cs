using System.Threading.Tasks;
using AutoMapper;
using Infinity.ExamProject.Bussiness.Interfaces;
using Infinity.ExamProject.Bussiness.Services;
using Infinity.ExamProject.Data.Entities;
using Infinity.ExamProject.Data.EntityFramework.Interfaces;
using Infinity.ExamProject.Dtos.OptionDtos;
using Infinity.ExamProject.Dtos.QuestiionOptionsDtos;
using Infinity.ExamProject.Dtos.QuestionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Infinity.ExamProject.Controllers
{
    public class QuestionOptionsController : Controller
    {
        private readonly IOptionService _optionService;
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IExamService _examService;

        public QuestionOptionsController(IOptionService optionService, IQuestionService questionService, IMapper mapper, IExamService examService)
        {
            _optionService = optionService;
            _questionService = questionService;
            _mapper = mapper;
            _examService = examService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var list = await _optionService.GetAllQuestionOption(id);
            ViewBag.Questions = list.FirstOrDefault()?.ExamId;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int ExamId)
        {
            ViewBag.Exam = await _examService.GetAllCategoriesAsync();
            var viewModel = new CreateQuestionOptionsDto
            {
                QuestionDto = new CreateQuestionDto(),
                OptionsDto = new List<CreateOptionDto>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionOptionsDto viewModel)
        {
            if (ModelState.IsValid)
            {
                await _questionService.Create(viewModel.QuestionDto);

                foreach (var optionDto in viewModel.OptionsDto)
                {
                    // Son eklenen Question'ın id'sini alıyoruz.
                    var questionList = await _questionService.GetAllQuestionAsync();
                    var latestQuestion = questionList.OrderByDescending(q => q.QuestionId).FirstOrDefault();

                    if (latestQuestion != null)
                    {
                        optionDto.QuestionId = latestQuestion.QuestionId;
                    }

                    if (optionDto.CorrectOption.ToString().ToLower() == "on")
                    {
                        optionDto.CorrectOption = true;
                    }
                    optionDto.QuestionId = latestQuestion.QuestionId;

                    await _optionService.Create(optionDto);
                }
                return RedirectToAction("Index", "QuestionOptions", new { id = viewModel.QuestionDto.ExamId });
            }
            return View(viewModel);
        }




        public async Task<IActionResult> Remove(int id)
        {
            var deletendata = await _questionService.GetById(id);
            var data = deletendata.ExamId;
            await _questionService.Remove(id);
            return RedirectToAction("Index", "QuestionOptions", new { id = data });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var questionData = await _questionService.GetById(id);
            var optionsData = await _optionService.OptionGetAll(id);

            var questionDto = _mapper.Map<UpdateQuestionDto>(questionData);
            var optionsDto = _mapper.Map<List<UpdateOptionDto>>(optionsData);

            var viewmodel = new UpdateQuestionOptionDto
            {
                QuestionDto = questionDto,
                Options = optionsDto
            };

            return View(viewmodel);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateQuestionOptionDto questionOptionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionService.Update(questionOptionDto.QuestionDto);
                foreach (var option in questionOptionDto.Options)
                {
                    await _optionService.Update(option);
                }
                return RedirectToAction("Index", "QuestionOptions", new { id = questionOptionDto.QuestionDto.ExamId });
            }
            return View(questionOptionDto);
        }

    }
}
