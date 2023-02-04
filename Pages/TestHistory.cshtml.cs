using ISTQBQuiz.Dtos;
using ISTQBQuiz.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISTQBQuiz.Pages;

public class TestHistory : PageModel
{
    public List<TestResultDto> _testHistory;
    public void OnGet()
    {
        TestResultService.GetTestResults();
        _testHistory = TestResultService._testResults;
    }
}