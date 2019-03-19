using Project_ComData.DataModel;
using Project_ComData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData.Repositories
{
    public class RateQuestionRepo
    {
        public List<RateQuestion> GetRateQuestions(QuestionRateDto questionRateDto)
        {
            using (var db = new UserDbContext())
            {
                List<RateQuestion> listRate = new List<RateQuestion>();
                listRate = db.RateQuestions.Where(c => c.QuestionId == questionRateDto.QuestionId).ToList();
                return listRate;
            }
        }

        public void Up(QuestionRateDto questionRateDto)
        {
            using (var db = new UserDbContext())
            {
                List<RateQuestion> listRate = new List<RateQuestion>();
                listRate = db.RateQuestions.Where(c => c.QuestionId == questionRateDto.QuestionId).ToList();
                var userRated = listRate.Find(c => c.UserId == questionRateDto.UserId);

                if (userRated == null)
                {
                    RateQuestion rq = new RateQuestion()
                    {
                        QuestionId = questionRateDto.QuestionId,
                        UserId = questionRateDto.UserId,
                        Up = true,
                        Down = false
                    };
                    db.RateQuestions.Add(rq);
                    db.SaveChanges();
                }
                else
                {
                    userRated.Up = true;
                    userRated.Down = false;
                    db.SaveChanges();
                }
            }
        }

        public int CountUps(int questionId)
        {
            int upCounter = 0;
            using (var db = new UserDbContext())
            {
                var list = db.RateQuestions.Where(c => c.QuestionId == questionId).ToList();
                foreach (var question in list)
                {
                    if (question.Up == true)
                    {
                        upCounter++;
                    }
                }
            }
            return upCounter;
        }

        public int CountDowns(int questionId)
        {
            int downCounter = 0;
            using (var db = new UserDbContext())
            {
                var list = db.RateQuestions.Where(c => c.QuestionId == questionId).ToList();
                foreach (var question in list)
                {
                    if (question.Down == true)
                    {
                        downCounter++;
                    }
                }
            }
            return downCounter;
        }

        public void Down(QuestionRateDto questionRateDto)
        {
            using (var db = new UserDbContext())
            {
                List<RateQuestion> listRate = new List<RateQuestion>();
                listRate = db.RateQuestions.Where(c => c.QuestionId == questionRateDto.QuestionId).ToList();
                var userRated = listRate.Find(c => c.UserId == questionRateDto.UserId);

                if (userRated == null)
                {
                    RateQuestion rq = new RateQuestion()
                    {
                        QuestionId = questionRateDto.QuestionId,
                        UserId = questionRateDto.UserId,
                        Up = false,
                        Down = true
                    };
                    db.RateQuestions.Add(rq);
                    db.SaveChanges();
                }
                else
                {
                    userRated.Up = false;
                    userRated.Down = true;
                    db.SaveChanges();
                }
            }
        }
    }
}