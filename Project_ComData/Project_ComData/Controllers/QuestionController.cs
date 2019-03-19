using Project_ComData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Project_ComData.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionController : Controller
    {

       public JsonResult AddQuestion([FromBody] Question q)
       {
            var repo = new QuestionRepo();
            if (repo.validateQuestion(q))
            {
                repo.AddQuestion(q);
                return Json(true);
            }
            else
                return Json(false);
       }

       public void DeleteQuestion([FromBody] Question q)
       {
            var repo = new QuestionRepo();
            repo.DeleteQuestion(q.QuestionId);
       }

        public JsonResult GetQuestion([FromBody] Question q)
        {
            var repo = new QuestionRepo();
            if (q.QuestionId > 1)
            {
                return Json(repo.getQuestion(q.QuestionId));
            } else
            {
                return Json(null);
            }
        }

        public JsonResult getQuestionsForUser([FromBody] User u)
        {
            var repo = new QuestionRepo();
            return Json(repo.GetQuestionsForUser(u.UserId));
        }

        public JsonResult GetQuestions()
        {
            var repo = new QuestionRepo();

            return Json(repo.getQuestions());
        }
    }
}