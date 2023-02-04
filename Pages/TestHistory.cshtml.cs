using ISTQBQuiz.Dtos;
using ISTQBQuiz.Models;
using ISTQBQuiz.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISTQBQuiz.Pages;

public class TestHistory : PageModel
{
    public List<TestResultDto> _testHistory;
    public double _passPercentage;
    public double _failPercentage;
    public void OnGet()
    {
        TestResultService.GetTestResults();
        _testHistory = TestResultService._testResults;
        _passPercentage = TestResultService._passPercentage;
        _failPercentage = TestResultService._failPercentage;
    }
}