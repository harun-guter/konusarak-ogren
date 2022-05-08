using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamController : ControllerBase
{
    private IExamService _examService;
    private IQuestionService _questionService;
    private int lastInsertExamId;

    public ExamController(IExamService examService, IQuestionService questionService)
    {
        _examService = examService;
        _questionService = questionService;
    }

    [HttpGet("get")]
    public ExamWithQuestion Get(int id) => _examService.GetExamWithQuestionById(id);

    [HttpGet("getall")]
    [Authorize]
    public IList<Exam> GetAll() => _examService.GetList();

    [HttpPost("add")]
    [Authorize]
    public ExamWithQuestion Add(ExamWithQuestion examWithQuestion)
    {
        _examService.Add(examWithQuestion.Exam);
        lastInsertExamId = examWithQuestion.Exam.Id;
        foreach (var question in examWithQuestion.Questions)
        {
            question.ExamId = lastInsertExamId;
            _questionService.Add(question);
        }
        return _examService.GetExamWithQuestionById(lastInsertExamId);
    }

    [HttpPut("update")]
    [Authorize]
    public ExamWithQuestion Update(ExamWithQuestion examWithQuestion)
    {
        _examService.Update(examWithQuestion.Exam);
        foreach (var question in examWithQuestion.Questions)
        {
            question.ExamId = examWithQuestion.Exam.Id;
            _questionService.Add(question);
        }
        return _examService.GetExamWithQuestionById(examWithQuestion.Exam.Id);
    }

    [HttpDelete("delete")]
    [Authorize()]
    public Exam Delete(int id)
    {
        var exam = _examService.GetById(id);
        exam.IsDeleted = true;
        return _examService.Update(exam);
    }

}
