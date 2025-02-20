using System.ComponentModel;
using System.Diagnostics;

public class Answer:BaseEntity {
   
    public required Question Question {get;set;}
    public int QuestionId {get;set;}
    public string? AnswerText {get;set;}
    public int? OptionId {get;set;} 
    public Option? Option {get;set;}
    public double? Rating {get;set;}
    public required Submission Submission {get;set;}
    public int SubmissionId {get;set;}

 
    
}