using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class QuestionController:Controller 
{
private readonly ApplicationDbContext _dbContext;

public QuestionController(ApplicationDbContext dbContext){
    _dbContext = dbContext;
}
    [HttpPost]
    public async void CreateQuestion(QuestionDto questionDto) {
        
        // Console.WriteLine(QuestionDto.IsRequired.ToString() +  QuestionDto.Options +  QuestionDto.QuestionText +  QuestionDto.QuestionType);
       Survey survey =  _dbContext.Surveys.Find(1);
       Question newQuestion = new Question(){
        QuestionText = questionDto.QuestionText,
        QuestionType = questionDto.QuestionType,
        Survey = survey
       };
       _dbContext.Add(newQuestion);

        await _dbContext.SaveChangesAsync();
       

    }

}
