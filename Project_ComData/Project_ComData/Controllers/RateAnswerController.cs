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
    public class RateAnswerController : Controller
    {
        public JsonResult GetRateAnswers([FromBody]AnswerRateDto answerRateDto)
        {
            var repo = new RateAnswerRepo();
            return Json(repo.GetRateAnswers(answerRateDto));
        }

        public void Up([FromBody]AnswerRateDto answerRateDto)
        {
            var repo = new RateAnswerRepo();
            repo.Up(answerRateDto);
        }

        public void Down([FromBody]AnswerRateDto answerRateDto)
        {
            var repo = new RateAnswerRepo();
            repo.Down(answerRateDto);
        }

        public JsonResult getUps([FromBody]Answer answer)
        {
            var repo = new RateAnswerRepo();
            return Json(repo.CountUps(answer.AnswerId));
        }

        public JsonResult getDowns([FromBody]Answer answer)
        {
            var repo = new RateAnswerRepo();
            return Json(repo.CountDowns(answer.AnswerId));
        }
    }
}