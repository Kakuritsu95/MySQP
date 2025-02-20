using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class SubmissionController:Controller 
{
    private readonly ApplicationDbContext _dbContext

    public SubmissionController(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }
    public void CreateSubmission() {
        
    }

}