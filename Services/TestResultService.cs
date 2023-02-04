using ISTQBQuiz.Dtos;

namespace ISTQBQuiz.Services;

public static class TestResultService
{
    public static List<TestResultDto> _testResults { get; set; }

    static TestResultService()
    {
        _testResults = new();
    }

    public static void GetTestResults()
    {
        var quizDbService = new QuizDatabaseService();
        _testResults = quizDbService.GetTestResults();
    }
}
