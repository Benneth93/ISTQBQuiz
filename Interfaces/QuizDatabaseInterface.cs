using ISTQBQuiz.Models;

namespace ISTQBQuiz.Interfaces
{
    public interface QuizDatabaseInterface
    {
        public QuestionModel GetQuestionByID(int id);
        public List<QuestionModel> GetNumberOfQuestions(int amount);

        public AnswerModel GetAnswerByID(int id);
        public List<AnswerModel> GetAnswers();
    }
}
