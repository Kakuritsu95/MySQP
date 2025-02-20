using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


public class Question:BaseEntity {
    public int SurveyId;
     public bool IsRequired {get;set;}

    [Required]
    public required string QuestionText {get;set;}

    [Required]
    public required QuestionType QuestionType {get;set;}

    public Collection<Option>? Options {get;set;}
    public Collection<Answer> Answers {get;set;}
    public required Survey Survey {get;set;}

    public Question(){}
}