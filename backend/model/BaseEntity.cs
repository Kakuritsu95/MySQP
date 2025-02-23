using System.ComponentModel.DataAnnotations;

public abstract class BaseEntity 
{   
    [Key]
    public int Id {get;set;}
    public DateTime? CreatedAt {get;set;}
    public DateTime? UpdatedAt {get;set;}

    public BaseEntity()
{
    CreatedAt = DateTime.Now;
    UpdatedAt = CreatedAt ?? UpdatedAt;
}
}