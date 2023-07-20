using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return StackAPIBackEnd();
        }
        public ActionResult StackAPIBackEnd()
        {
            ViewData["Questions"] = new API.StackOverFlowApi().GetQuestions();
            return View("StackAPIBackEnd");
        }
        public ActionResult GetQuestionAnswers(int QuestionId)
        {
            return Json(new API.StackOverFlowApi().GetAnswers(QuestionId.ToString()), JsonRequestBehavior.AllowGet);
        }

    }
}
