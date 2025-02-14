using System.ComponentModel.DataAnnotations;

public class Survey:BaseEntity 
 {
    [Required]
    public string Name {get;set;}
    
    public Survey(string name){
        Name=name;
    }

    public int AuthorId {get;set;}
    public User Author {get;set;}
}