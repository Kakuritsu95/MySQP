using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/[controller]")]
public class SubmissionController:Controller 
{
    private readonly ApplicationDbContext _dbContext;

    public SubmissionController(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

  [HttpGet]
public ActionResult<List<SubmissionDto>> GetSubmissions()
{
    List<SubmissionDto> submissions = _dbContext.Submission
        .Include(s => s.Answers)
            .ThenInclude(a => a.Question)
        .Select(s => new SubmissionDto
        {
            SurveyId = s.SurveyId,
          
            Answers = s.Answers.Select(a => new AnswerDto
            {
                AnswerText = a.AnswerText,
                OptionId = a.QuestionId,
                Question = new QuestionDto
                {
                    IsRequired = a.Question.IsRequired,
                    Options = a.Question.Options.Select(opt => opt.ToString()).ToList(),
                    QuestionText = a.Question.QuestionText,
                    QuestionType = a.Question.QuestionType
                }
            }).ToList() 
        }).ToList(); 

    return Ok(submissions); 
}


    [HttpPost]
    public void CreateSubmission(SubmissionRequest request) {        
       Survey surveyToSubmit =  _dbContext.Surveys.Find(request.SurveyId);
      
       Submission newSubmission = new Submission();
       newSubmission.Survey = surveyToSubmit;
       newSubmission.Answers = new Collection<Answer>();
       newSubmission.SurveyId = request.SurveyId;
         Console.WriteLine("Before loop");
       Collection<Answer> answers = new Collection<Answer> (request.answers.Select(answer=> {
          Console.WriteLine("In loop");
            Question question = _dbContext.Questions.Find(answer.QuestionId);
               Console.WriteLine(question.QuestionText + "LOOOOOOOOL");
            return new Answer(){
                Question = question,
                QuestionId = question.Id,
                AnswerText = answer.AnswerText,
                Submission = newSubmission,
                SubmissionId = newSubmission.Id,            
            };
           
        }).ToList());
        newSubmission.Answers = answers;      
         foreach(var ans in answers){
            Console.WriteLine(ans.AnswerText);
         }
        if(!newSubmission.IsSubmissionValid()){
            throw new Exception("Not valid submission");
        }
        _dbContext.Add(newSubmission);
        _dbContext.SaveChanges();
    }

}