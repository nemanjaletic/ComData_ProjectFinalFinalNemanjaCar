using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int? QuestionId { get; set; }
    }
}