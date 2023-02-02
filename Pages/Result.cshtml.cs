using ISTQBQuiz.Models;
using ISTQBQuiz.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISTQBQuiz.Pages;

public class Result : PageModel
{
    public int _correctAnswers;
    public List<QuestionModel> _questions = new ();
    public List<AnswerModel> _answers = new();
    public List<AnswerModel> _userAnswers = new();
    public int _maxQuestions;
    
    public void OnGet()
    {
        _questions = QuizService._questions;
        _answers = QuizService._answers;
        _userAnswers = QuizService._userAnswers;
        _maxQuestions = QuizService._maxQuestions;
        _correctAnswers = QuizService.CheckAnswers();
    }
}