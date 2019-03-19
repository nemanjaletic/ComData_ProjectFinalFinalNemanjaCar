using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public class QuestionRateDto
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
    }
}