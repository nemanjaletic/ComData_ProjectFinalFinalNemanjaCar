using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int Type { get; set; }

    }
}