using Project_ComData.Models;
using Project_ComData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Project_ComData.Controllers
{
    public class RateQuestionController : Controller
    {
        public JsonResult GetRateQuestions([FromBody]QuestionRateDto questionRateDto)
        {
            var repo = new RateQuestionRepo();
            return Json(repo.GetRateQuestions(questionRateDto));
        }

        public void Up([FromBody]QuestionRateDto questionRateDto)
        {
            var repo = new RateQuestionRepo();
            repo.Up(questionRateDto);
        }

        public void Down([FromBody]QuestionRateDto questionRateDto)
        {
            var repo = new RateQuestionRepo();
            repo.Down(questionRateDto);
        }

        public JsonResult getUps([FromBody]Question question)
        {
            var repo = new RateQuestionRepo();
            return Json(repo.CountUps(question.QuestionId));
        }

        public JsonResult getDowns([FromBody]Question question)
        {
            var repo = new RateQuestionRepo();
            return Json(repo.CountDowns(question.QuestionId));
        }
    }
}