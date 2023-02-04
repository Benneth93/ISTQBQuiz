namespace ISTQBQuiz.Models;

public class TestResultModel
{
    public double Percentage { get; set; }
    public string Result { get; set; }
    public int CorrectAnswers { get; set; }
    public string DateAndTimeOfTest { get; set; }
}