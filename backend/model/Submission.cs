using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

public class Submission: BaseEntity {
    public User? User {get;set;} 

    public  Survey Survey {get;set;}

    public int SurveyId {get;set;}
    
    public  Collection<Answer> Answers {get;set;}
    
    public Submission(){}

    public Submission(Survey survey, Collection<Answer> answers, int surveyId){
        Survey = survey;
        SurveyId = surveyId;
        Answers = answers;
    }

    public bool IsSubmissionValid(){

if(Answers.Any(a=>(a.Question.IsRequired && string.IsNullOrEmpty(a.AnswerText) && a.OptionId == null && a.Rating == null) ||(!Survey.IsAnnonymous && User==null)))
{
   return false;
}

var answerQuestionIds = Answers.Select(a=>a.QuestionId);
foreach (var q in Survey.Questions){
    Console.WriteLine("WTF?");
    Console.WriteLine(q.Id);
    if(q.IsRequired && !answerQuestionIds.Any(id=>id==q.Id)){
        return false;
    }; 
}

    foreach (var ans in Answers){
            Console.WriteLine(ans.OptionId==null);
            Console.WriteLine("WTH");

        }
    
   foreach(Answer answer in Answers){
    switch (answer.Question.QuestionType)
        {
              case QuestionType.TEXT:
                if (string.IsNullOrEmpty(answer.AnswerText))
                {
                    return false;
                }
                break;

            case QuestionType.MULTIPLE_CHOISE:
                if (!answer.OptionId.HasValue || !answer.Question.Options.Any(o => o.Id == answer.OptionId.Value))
                {
                    return false;
                }
                break;

            case QuestionType.RATING:
                if (!answer.Rating.HasValue || answer.Rating.Value <= 0 || answer.Rating.Value > 10)
                {
                    return false;
                }
                break;

            default:
                return false;
        }       
       
    }  
     return true;
    }
   
}