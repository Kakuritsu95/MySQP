public class SubmissionDto {
    public int SurveyId {get;set;}
    public int UserId {get;set;}
    public List<AnswerDto> Answers {get;set;} = new List<AnswerDto>();
}