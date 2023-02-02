using ISTQBQuiz.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISTQBQuiz.Pages
{
    public class QuizModel : PageModel
    {
        public string _currentQuestion { get; set; }
        public int _questionNumber;
        
        public QuizModel()
        {
            _questionNumber = QuizService.GetQuestionNumber();
        }

        public IActionResult OnPost()
        {
            string answer = Request.Form["answer"];
            QuizService.AnswerQuestion(answer);
            
            if (_questionNumber == QuizService._maxQuestions)
            {
                return new RedirectResult("/Result");
            }
            
            QuizService.NextQuestion();
            _currentQuestion = QuizService.GetQuestion();
            _questionNumber = QuizService.GetQuestionNumber();

            return Page();
        }
        

        
        public void OnGet()
        {
            //Initialize the quiz on page load
            QuizService.GetQuestionImages();

            _currentQuestion = QuizService.GetQuestion();
        }
    }
}
