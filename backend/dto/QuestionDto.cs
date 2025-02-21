using Microsoft.Extensions.Options;

public class QuestionDto {

    public  bool IsRequired {get;set;} = false;

    public  string QuestionText {get;set;}

    public  QuestionType QuestionType {get;set;}

    public  List<string>? Options {get;set;}


    
}