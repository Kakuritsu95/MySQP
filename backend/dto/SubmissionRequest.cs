using System.Collections.ObjectModel;

public class SubmissionRequest 
{
    public int SurveyId {get;set;}
    public required Collection<AnswerDto> answers;
    public int? UserId {get;set;}
}