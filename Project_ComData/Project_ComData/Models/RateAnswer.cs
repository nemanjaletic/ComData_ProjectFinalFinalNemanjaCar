using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public class RateAnswer: Rating
    {
        [ForeignKey("AnswerId")]
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
    }
}