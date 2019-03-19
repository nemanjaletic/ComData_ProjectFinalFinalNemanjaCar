namespace Project_ComData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RateAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        Up = c.Boolean(nullable: false),
                        Down = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.AnswerId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RateQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Up = c.Boolean(nullable: false),
                        Down = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RateQuestions", "UserId", "dbo.Users");
            DropForeignKey("dbo.RateQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.RateAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.RateAnswers", "AnswerId", "dbo.Answers");
            DropIndex("dbo.RateQuestions", new[] { "UserId" });
            DropIndex("dbo.RateQuestions", new[] { "QuestionId" });
            DropIndex("dbo.RateAnswers", new[] { "UserId" });
            DropIndex("dbo.RateAnswers", new[] { "AnswerId" });
            DropTable("dbo.RateQuestions");
            DropTable("dbo.RateAnswers");
        }
    }
}
