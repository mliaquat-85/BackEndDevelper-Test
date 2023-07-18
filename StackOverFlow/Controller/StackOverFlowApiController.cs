using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StackOverFlowApiController : ApiController
    {
        public StackOverFlowQuestionData GetQuestions()
        {
            return new StackOverFlowAPI().GetQuestions();
        }
        public StackOverFlowAnswerData GetAnswers(string question_id)
        {
            return new StackOverFlowAPI().GetAnswers(question_id);
        }

    }
}
