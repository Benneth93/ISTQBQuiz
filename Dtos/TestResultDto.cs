using System.Diagnostics.Contracts;

namespace ISTQBQuiz.Dtos;

public class TestResultDto
{
    public int? TestResultID { get; set; }
    public double Percentage { get; set; }
    public string Result { get; set; }
    public int CorrectAnswers { get; set; }
    public string DateAndTimeOfTest { get; set; }
}