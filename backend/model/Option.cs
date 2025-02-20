using System.ComponentModel.DataAnnotations;

public class Option:BaseEntity {
    public int QuestionId {get;set;}

    public Question Question {get;set;}

    [Required]
    public required string OptionText {get;set;}
}