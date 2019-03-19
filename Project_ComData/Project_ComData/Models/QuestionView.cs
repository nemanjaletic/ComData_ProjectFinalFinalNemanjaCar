using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public class QuestionView
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}