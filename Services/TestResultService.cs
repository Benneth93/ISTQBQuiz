using ISTQBQuiz.Dtos;
using ISTQBQuiz.Models;

namespace ISTQBQuiz.Services;

public static class TestResultService
{
    public static List<TestResultDto> _testResults { get; set; }
    public static double _passPercentage { get; set; }
    public static double _failPercentage { get; set; }
    
    static TestResultService()
    {
        _testResults = new();
    }

    public static void GetTestResults()
    {
        var quizDbService = new QuizDatabaseService();
        _testResults = quizDbService.GetTestResults();
        CalculatePassPercentage();
    }

    private static void CalculatePassPercentage()
    {
        var numberOfPassResults = _testResults.Count(result => result.Result == "PASS");
        var numberOfFailResults = _testResults.Count(result => result.Result == "FAIL");

        _passPercentage = (numberOfPassResults / _testResults.Count) * 100;
        _failPercentage = (numberOfFailResults / _testResults.Count) * 100;
        
    }
}
