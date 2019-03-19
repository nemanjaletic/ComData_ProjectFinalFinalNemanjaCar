using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_ComData.Models
{
    public class UserView
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}