using Project_ComData.DataModel;
using Project_ComData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData
{
    public class UserRepo
    {

        //[HttpPost]
        public bool Validate(User user)
        {
            if ((string.IsNullOrWhiteSpace(user.UserName)) || string.IsNullOrWhiteSpace(user.Password))
                return false;
            else
                return true;
        }

        public bool ValidateRegister(User user)
        {
            if ((string.IsNullOrWhiteSpace(user.UserName)) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            {
                return false;
            }
            return true;
        }

        public bool Register(User user)
        {           
                using (var db = new UserDbContext())
                {
                    var userExists = db.Users.Where(c=>c.UserName == user.UserName).FirstOrDefault();

                    if (userExists == null)
                    {
                        user.RoleId = 2;
                        db.Users.Add(user);
                        db.SaveChanges();
                        return true;
                    }
                }           
            return false;
        }
        

        public Result Login(User user)
        {
            using (var db = new UserDbContext())
            {            
                var selectedUser = (from User in db.Users where
                                    User.UserName == user.UserName && User.Password == user.Password select User).FirstOrDefault();

                if (selectedUser == null)
                {
                    return new Result() { LoginSuccessful = false, User = null };
                }         
                else
                    return new Result() { LoginSuccessful = true, User = selectedUser };
            }
        }
        public bool EditUser(User u)

        {
            using (var db = new UserDbContext())
            {

                var user = db.Users.Where(c => c.UserId == u.UserId).First();
                if (user != null)
                {
                    user = u;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }

        }
        public List<UserView> GetAll()
        {
            using (var db = new UserDbContext())
            {

                var usersView = new List<UserView>();
                usersView = db.Users.Join(db.Roles, c => c.RoleId, x => x.RoleId, (c, x) =>
                 new UserView
                 {
                     UserId = c.UserId,
                     Firstname = c.FirstName,
                     Lastname = c.LastName,
                     UserName = c.UserName,
                     RoleId = x.RoleId
                 }).ToList();
                return usersView;
            }
        }
        public void DeleteUser(User user)
        {
            using (var db = new UserDbContext())
            {

                var deleteUser = db.Users.Where(c => c.UserId == user.UserId).FirstOrDefault();
                db.Users.Remove(deleteUser);
                db.SaveChanges();
                
            }
        }
    }
}