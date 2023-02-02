using ISTQBQuiz.Models;
using ISTQBQuiz.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISTQBQuiz.Controllers
{
    public class QuizController: Controller
    {
        QuizDatabaseService _quizDatabaseService;
        public List<QuestionModel> _questions;
        public List<string> _questionImageStrings;
        int questionIndex = 0;
        IConfiguration _configuration;
        //QuizModel model = new();

        public string currentImage { get; set; }

        public QuizController(IConfiguration config) 
        {
            //_quizDatabaseService = new QuizDatabaseService(config);
        }

        // GET: QuizController
        [HttpGet]
        public IActionResult Index()
        {
            GetImages();


            return View();
        }

      

        [HttpPost]
        //public IActionResult GetNextQuestion() 
        //{
        //    //questionIndex++;
        //    //model.currentImage = _questionImageStrings[questionIndex];
        //    //return View(model); 
        //}
      public void GetImages()
      {
            /*_quizDatabaseService = new(_configuration);
            _questionImageStrings = new();
            _questions = _quizDatabaseService.GetNumberOfQuestions(40);

            foreach (var question in _questions)
            {
                _questionImageStrings.Add(Convert.ToBase64String(question.image));
            }

            currentImage = _questionImageStrings[questionIndex];*/

      }
    }
}
