using Project_ComData.DataModel;
using Project_ComData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData.Repositories
{
    public class RateAnswerRepo
    {
        public List<RateAnswer> GetRateAnswers(AnswerRateDto answerRateDto)
        {
            using (var db = new UserDbContext())
            {
                List<RateAnswer> listRate = new List<RateAnswer>();
                listRate = db.RateAnswers.Where(c => c.AnswerId == answerRateDto.AnswerId).ToList();
                return listRate;
            }
        }

        public void Up(AnswerRateDto answerRateDto)
        {
            using (var db = new UserDbContext())
            {
                List<RateAnswer> listRate = new List<RateAnswer>();
                listRate = db.RateAnswers.Where(c => c.AnswerId == answerRateDto.AnswerId).ToList();
                var userRated = listRate.Find(c => c.UserId == answerRateDto.UserId);

                if (userRated == null)
                {
                    RateAnswer r = new RateAnswer()
                    {
                        AnswerId = answerRateDto.AnswerId,
                        UserId = answerRateDto.UserId,
                        Up = true,
                        Down = false
                    };
                    db.RateAnswers.Add(r);
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

        public int CountUps(int AnswerId)
        {
            int upCounter = 0;
            using (var db = new UserDbContext())
            {
                var list = db.RateAnswers.Where(c => c.AnswerId == AnswerId).ToList();
                foreach (var answer in list)
                {
                    if (answer.Up == true)
                    {
                        upCounter++;
                    }
                }
            }
            return upCounter;
        }

        public int CountDowns(int answerId)
        {
            int downCounter = 0;
            using (var db = new UserDbContext())
            {
                var list = db.RateAnswers.Where(c => c.AnswerId == answerId).ToList();
                foreach (var answer in list)
                {
                    if (answer.Down == true)
                    {
                        downCounter++;
                    }
                }
            }
            return downCounter;
        }

        public void Down(AnswerRateDto answerRateDto)
        {
            using (var db = new UserDbContext())
            {
                List<RateAnswer> listRate = new List<RateAnswer>();
                listRate = db.RateAnswers.Where(c => c.AnswerId == answerRateDto.AnswerId).ToList();
                var userRated = listRate.Find(c => c.UserId == answerRateDto.UserId);

                if (userRated == null)
                {
                    RateAnswer ra = new RateAnswer()
                    {
                        AnswerId = answerRateDto.AnswerId,
                        UserId = answerRateDto.UserId,
                        Up = false,
                        Down = true
                    };
                    db.RateAnswers.Add(ra);
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