using Project_ComData.DataModel;
using Project_ComData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData
{
    public class QuestionRepo
    {
        public List<QuestionView> getQuestions()
        {
            using (var db = new UserDbContext())
            {
                var questions = new List<QuestionView>();
                //return questions = db.Questions.ToList();


                questions = db.Questions.Join(db.Users, c => c.UserId, x => x.UserId, (c, x) =>
                new QuestionView
                {
                    Title = c.Title,
                    Body = c.Body,
                    QuestionId = c.QuestionId,
                    Timestamp = c.Timestamp,
                    UserId = x.UserId,
                    Firstname = x.FirstName,
                    Lastname = x.LastName
                }).ToList();
                return questions;
            }
        }

        public List<QuestionView> GetQuestionsForUser(int id)
        {
            using (var db = new UserDbContext())
            {
                List<QuestionView> questionView = new List<QuestionView>();

                questionView = db.Questions.Join(db.Users, c => c.UserId, x => x.UserId, (c, x) =>
                new QuestionView
                {
                    Title = c.Title,
                    Body = c.Body,
                    QuestionId = c.QuestionId,
                    Timestamp = c.Timestamp,
                    UserId = x.UserId,
                    Firstname = x.FirstName,
                    Lastname = x.LastName
                }).ToList<QuestionView>();

                var questionViewReturn = new List<QuestionView>();

                foreach (var question in questionView)
                {
                    if (question.UserId == id)
                    {
                        questionViewReturn.Add(question);
                    }
                }
                return questionViewReturn;
            }
        }

        public QuestionView getQuestion(int id)
        {
            using (var db = new UserDbContext())
            {
                QuestionView questionView = new QuestionView();
                questionView = db.Questions.Join(db.Users, c => c.UserId, x => x.UserId, (c, x) =>
                new QuestionView
                {
                    Title = c.Title,
                    Body = c.Body,
                    QuestionId = c.QuestionId,
                    Timestamp = c.Timestamp,
                    UserId = x.UserId,
                    Firstname = x.FirstName,
                    Lastname = x.LastName
                }).Where(c => c.QuestionId == id).First();
                return questionView;
            }
        }

        public void AddQuestion(Question question)
        {
            using (var db = new UserDbContext())
            {
                question.Timestamp = DateTime.Now;
                db.Questions.Add(question);
                db.SaveChanges();
            }
        }

        public void DeleteQuestion(int id)
        {
            using (var db = new UserDbContext())
            {
                var questionForDelete = db.Questions.Where(c => c.QuestionId == id).First();
                db.Questions.Remove(questionForDelete);
                db.SaveChanges();
            }
        }

        public bool validateQuestion(Question question)
        {
            if (string.IsNullOrWhiteSpace(question.Title) || string.IsNullOrWhiteSpace(question.Body))
            {
                return false;
            }
            return true;
        }
    }
}