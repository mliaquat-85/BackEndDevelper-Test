using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Categories"] = new BookController().GetCategories(0, 0);
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetSubCategories(int CategoryId)
        {
            return Json(new BookController().GetCategories(0, CategoryId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBooks(int CategoryId)
        {
            return Json(new BookController().GetBooksByCategoryId(CategoryId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult StackAPI()
        {
            return View();
        }

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
