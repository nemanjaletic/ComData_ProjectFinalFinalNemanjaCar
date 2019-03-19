using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public abstract class Rating
    {
        [Key]
        public int Id { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}