using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class SurveyController:Controller 
{
    private readonly ApplicationDbContext _dbContext;
    public SurveyController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<Survey[]> GetAllSurveys()
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        Console.WriteLine(ipAddress);
        Survey[] surveys = _dbContext.Surveys.ToArray();
        return Ok(surveys);
    }

    [HttpGet("{authorId}")] 
    public ActionResult<Survey[]> GetSurveysByAuthorId(int authorId)
    {
      var authorSurveys =  _dbContext.Surveys.Where(s=>s.AuthorId==authorId).Include(s=>s.Author);
    
      return Ok(authorSurveys);
    }

    [HttpPost]
    public ActionResult<Survey> CreateSurvey(SurveyDto surveyDto){
            Survey newSurvey = new Survey(surveyDto.Name);
            newSurvey.AuthorId = surveyDto.OwnerId;
           _dbContext.Add(newSurvey);
           _dbContext.SaveChanges();        
      return Ok(newSurvey);
    }
}