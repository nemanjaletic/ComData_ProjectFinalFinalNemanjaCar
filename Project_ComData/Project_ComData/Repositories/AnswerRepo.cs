using Project_ComData.DataModel;
using Project_ComData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Project_ComData.Repositories
{
    public class AnswerRepo
    {
        public bool Validate(Answer answer)
        {
            if (string.IsNullOrWhiteSpace(answer.Body))
            {
                return false;
            }
            return true;
        }

        public void AddAnswer(Answer answer)
        {
            using (var db = new UserDbContext())
            {
                answer.Timestamp = DateTime.Now;
                db.Answers.Add(answer);
                db.SaveChanges();
            }
        }

        public List<Answer> GetAnswers()
        {
            using (var db = new UserDbContext())
            {
                var answers = new List<Answer>();
                return answers = db.Answers.ToList();

            }
        }

        public List<AnswerView> GetAnswersForQuestion(Question q)
        {
            using (var db = new UserDbContext())
            {
                List<AnswerView> answerView = new List<AnswerView>();

                answerView = db.Answers.Join(db.Users, c => c.UserId, x => x.UserId, (c, x) =>
                new AnswerView
                {
                    AnswerId = c.AnswerId,
                    Body = c.Body,
                    QuestionId = c.QuestionId,
                    Timestamp = c.Timestamp,
                    UserId = x.UserId,
                    Firstname = x.FirstName,
                    Lastname = x.LastName
                }).ToList<AnswerView>();

                var answerViewReturn = new List<AnswerView>();

                foreach (var question in answerView)
                {
                    if (question.QuestionId == q.QuestionId)
                    {
                        answerViewReturn.Add(question);
                    }
                }
                return answerViewReturn;
            }
        }

        public List<AnswerView> GetAnswersFromUser(User u)
        {
            using (var db = new UserDbContext())
            {
                List<AnswerView> answerView = new List<AnswerView>();

                answerView = db.Answers.Join(db.Users, c => c.UserId, x => x.UserId, (c, x) =>
                new AnswerView
                {
                    AnswerId = c.AnswerId,
                    Body = c.Body,
                    QuestionId = c.QuestionId,
                    Timestamp = c.Timestamp,
                    UserId = x.UserId,
                    Firstname = x.FirstName,
                    Lastname = x.LastName
                }).ToList<AnswerView>();

                var answerViewReturn = new List<AnswerView>();

                foreach (var question in answerView)
                {
                    if (question.UserId == u.UserId)
                    {
                        answerViewReturn.Add(question);
                    }
                }
                return answerViewReturn;
            }
        }

        public void EditAnswer(Answer answerToEdit)
        {
            using (var db = new UserDbContext())
            {
                Answer a = db.Answers.Find(answerToEdit.AnswerId);
                a.Body = answerToEdit.Body;
                a.Timestamp = DateTime.Now;
                db.SaveChanges();

            }
        }

        public void DeleteAnswer(Answer answer)
        {
            using (var db = new UserDbContext())
            {
                db.Answers.Remove(answer);
            }
        }
    }

    
}