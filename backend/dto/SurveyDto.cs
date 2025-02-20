using System.ComponentModel.DataAnnotations;

public class SurveyDto {   
   [Required]
    public string Title {get;set;}
    
    public int OwnerId {get;set;}
    public required SurveyType? SurveyType {get;set;}

 }