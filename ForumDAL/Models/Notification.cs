﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int Post_Id { get; set; }

        public string Message { get; set; }

        public int UserId { get; set; }
        public bool Checked { get; set; }
        public int CommentID { get; set; }
    }
}
