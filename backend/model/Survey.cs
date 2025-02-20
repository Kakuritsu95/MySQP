using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Survey:BaseEntity 
 {
    [Required]
    public string Title {get;set;}
    [Required]    
    public SurveyType SurveyType {get;set;}
    public string Description {get;set;}
    public int AuthorId {get;set;}
    public User Author {get;set;}
    public Collection<Question> Questions {get;set;}
    public bool IsAnnonymous {get;set;}

    public Collection<Submission> Submissions {get;set;}
    public Survey(string title){
        Title=title;
        
    }
    
}