using Project_ComData.Models;
using Project_ComData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Project_ComData.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnswerController : Controller
    {
        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }
   
        public JsonResult AddAnswer([FromBody] Answer answer)
        {
            var repo = new AnswerRepo();
               if (repo.Validate(answer))
                {
                    repo.AddAnswer(answer);
                return Json(true);
                }                      
            return Json(false);
        }

        public JsonResult GetAnswers()
        {
            var repo = new AnswerRepo();
            return Json(repo.GetAnswers());
        }

        public JsonResult GetAnswersForQuestion([FromBody] Question q)
        {
            var repo = new AnswerRepo();
            return Json(repo.GetAnswersForQuestion(q));
  
        }

        public JsonResult GetAnswersFromUser([FromBody] User u)
        {
            var repo = new AnswerRepo();
            return Json(repo.GetAnswersFromUser(u));
        }

        public JsonResult EditAnswer([FromBody] Answer a)
        {
            var repo = new AnswerRepo();
            if (repo.Validate(a))
            {
                repo.EditAnswer(a);
                return Json(true);
            }
            else
                return Json(false);
            
        }

        public void DeleteAnswer([FromBody] Answer a)
        {
            var repo = new AnswerRepo();
            repo.DeleteAnswer(a);
           
        }




    }
}