using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

public class Submission: BaseEntity {
    public User? User {get;set;} 

    public required Survey Survey {get;set;}

    public int SurveyId {get;set;}
    
    public required Collection<Answer> Answers {get;set;}

    public bool IsSubmissionValid(){
     if(Answers.Any(a=>a.Question.IsRequired && string.IsNullOrEmpty(a.AnswerText) || a.OptionId==null || a.Rating==null) || !Survey.IsAnnonymous && User==null) return false;

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