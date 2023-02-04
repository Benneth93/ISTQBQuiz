using ISTQBQuiz.Dtos;
using ISTQBQuiz.Interfaces;
using ISTQBQuiz.Models;
using MySqlConnector;

namespace ISTQBQuiz.Services
{
    public class QuizDatabaseService : QuizDatabaseInterface
    {
        MySqlConnection _quizDbConnection;
        private List<int> _questionIDs;
        
        public QuizDatabaseService() 
        {
                _quizDbConnection = new MySqlConnection(AppSettingsService.GetConnectionString("Default"));
        }

        public AnswerModel GetAnswerByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AnswerModel> GetAnswers()
        {
            var qIdString = "";
            List<AnswerModel> answerList = new();
            var lastID = _questionIDs.Last();
            foreach (var id in _questionIDs)
            {
                if (id.Equals(lastID)) qIdString += $"{id} ";
                else qIdString += $"{id}, ";
            }

            var sql = @$"SELECT * FROM QuestionSets.Answers
                         WHERE QuestionID in ({qIdString})";
            _quizDbConnection.Open();

            using (var command = new MySqlCommand(sql, _quizDbConnection))
            {
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var returnedID = reader.GetInt32("QuestionID");
                    var returnedAnswer = reader.GetString("Answer");
                    
                    answerList.Add(new AnswerModel
                    {
                        QuestionID = returnedID,
                        Answer = returnedAnswer
                    });
                }
            }

            _quizDbConnection.Close();
            
            return answerList;
        }

        public List<QuestionModel> GetNumberOfQuestions(int amount)
        {
           
            _questionIDs = generateIDs(amount);
            var qIdString = "";
            List<QuestionModel> questionList = new();
            var lastID = _questionIDs.Last();
            foreach (var id in _questionIDs) 
            {
                if (id.Equals(lastID)) qIdString += $"{id} ";
                else qIdString += $"{id}, ";
            }

            var sql = @$"SELECT * FROM QuestionSets.QuestionsBlobs
                      WHERE QuestionID in ({qIdString})";

            _quizDbConnection.Open();
            using (var command = new MySqlCommand(sql, _quizDbConnection))
            {
                using MySqlDataReader reader = command.ExecuteReader();
                int blobSize = 300000;
                while (reader.Read()) 
                {
                    var returnedID = reader.GetInt32("QuestionID");
                    var image = new byte[blobSize];
                    reader.GetBytes("QuestionImage", 0, image, 0, blobSize);

                  
                    questionList.Add(new QuestionModel {
                        QuestionId = returnedID,
                        image = Convert.ToBase64String(image)
                    });
                }
            }

            _quizDbConnection.Close();
            
            return questionList;
        }

        public QuestionModel GetQuestionByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<int> generateIDs(int amount)
        {
            var questionIDs = new List<int>();
            Random random = new();

            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < amount) numbers.Add(random.Next(1, 120));
            questionIDs = numbers.ToList();

            return questionIDs;
        }

        public void RecordResultToDatabase(TestResultModel result)
        {
            var sql = @$"INSERT INTO QuestionSets.TestHistory
                        (CorrectAnswers, Percentage, Result, DateTimeOfTest)
                        VALUES ({result.CorrectAnswers}, {result.Percentage}, '{result.Result}', '{result.DateAndTimeOfTest}')";

            var command = new MySqlCommand(sql, _quizDbConnection);
            _quizDbConnection.Open();
            command.ExecuteReader();
            _quizDbConnection.Close();

        }

        public List<TestResultDto> GetTestResults()
        {
            var sql = $@"SELECT * FROM QuestionSets.TestHistory";
            var testResults = new List<TestResultDto>();
            
            _quizDbConnection.Open();
            using (var command = new MySqlCommand(sql, _quizDbConnection))
            {
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    testResults.Add(new TestResultDto
                    {
                        TestResultID = reader.GetInt32("TestResultID"),
                        CorrectAnswers = reader.GetInt32("CorrectAnswers"),
                        Percentage = reader.GetDouble("Percentage"),
                        Result = reader.GetString("Result"),
                        DateAndTimeOfTest = reader.GetString("DateTimeOfTest")
                    });
                }
            }

            return testResults;
        }
    }
}
