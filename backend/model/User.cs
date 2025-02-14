public class User:BaseEntity {
    public string Email {get;set;}
    public string Username {get;set;}
    public string Password {get;set;}    
    public ICollection<Survey> Surveys {get;} = new List<Survey>();
}