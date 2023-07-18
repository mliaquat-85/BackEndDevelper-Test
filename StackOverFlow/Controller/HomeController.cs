using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult StackAPIBackEnd()
        {
            ViewData["Questions"] = new StackOverFlowApiController().GetQuestions();
            return View();
        }
        public ActionResult GetQuestionAnswers(int QuestionId)
        {
            return Json(new StackOverFlowApiController().GetAnswers(QuestionId), JsonRequestBehavior.AllowGet);
        }
    }
}
