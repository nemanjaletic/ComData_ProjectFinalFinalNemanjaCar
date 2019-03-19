using System.Data.Entity;
using Project_ComData.Models;

namespace Project_ComData.DataModel
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<RateQuestion> RateQuestions { get; set; }
        public DbSet<RateAnswer> RateAnswers { get; set; }

        public UserDbContext():base ("DefaultConnection")
        {
            
        }
    }
}