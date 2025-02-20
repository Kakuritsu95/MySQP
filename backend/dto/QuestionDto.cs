using Microsoft.Extensions.Options;

public class QuestionDto {

    public required bool IsRequired {get;set;} = false;

    public required string QuestionText {get;set;}

    public required QuestionType QuestionType {get;set;}

    public required List<string>? Options {get;set;}


    
}