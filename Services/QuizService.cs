using ISTQBQuiz.Models;

namespace ISTQBQuiz.Services;

public static class QuizService
{
    public static int _questionIndex  { get; set; }
    public static List<string> _questionStrings { get; set; }
    public static List<AnswerModel> _answers { get; set; }
    public static List<QuestionModel> _questions { get; set; }
    public static List<AnswerModel> _userAnswers { get; set; }
    public static readonly int _maxQuestions = 40;

    static QuizService()
    {
        _questionIndex = 0;
        _userAnswers = new();
    }

    public static void GetQuestionImages()
    {
        _questions = new List<QuestionModel>();
        _questionStrings = new List<string>();
        var dbService = new QuizDatabaseService();
        
        _questions = dbService.GetNumberOfQuestions(_maxQuestions);
        _answers = dbService.GetAnswers();
    }

    public static void AnswerQuestion(string answer)
    {
        _userAnswers.Add(new AnswerModel{QuestionID = _questionIndex+1, Answer = answer});
    }

    public static void NextQuestion()
    {
        _questionIndex++;
    }

    public static string GetQuestion()
    {
        return _questions[_questionIndex].image;
    }

    public static int GetQuestionNumber()
    {
        return _questionIndex + 1;
    }

    public static int CheckAnswers()
    {
        var numberOfCorrectAnswers = 0;
        for (var i = 0; i < _maxQuestions; i++)
        {
            if (_answers[i].Answer == _userAnswers[i].Answer) numberOfCorrectAnswers++;
        }

        _questionIndex = 0;
        return numberOfCorrectAnswers;
    }
}