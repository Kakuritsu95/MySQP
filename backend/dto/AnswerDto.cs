public class AnswerDto 
{
     public int QuestionId {get;set;}
     public string? AnswerText {get;set;}
     public int? OptionId {get;set;} 
     public double? Rating {get;set;}
     public QuestionDto Question {get;set;} 
     
}