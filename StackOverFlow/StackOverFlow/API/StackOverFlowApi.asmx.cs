using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StackOverFlow.API
{
    /// <summary>
    /// Summary description for StackOverFlowApi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StackOverFlowApi : System.Web.Services.WebService
    {

        [WebMethod]
        public StackOverFlowQuestionData GetQuestions()
        {
            return new StackOverFlowAPI().GetQuestions();
        }
        [WebMethod]
        public StackOverFlowAnswerData GetAnswers(string question_id)
        {
            return new StackOverFlowAPI().GetAnswers(question_id);
        }

    }
}
