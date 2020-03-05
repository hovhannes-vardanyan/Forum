﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public abstract class Message
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        //public int SubtopicID { get; set; }

        //public int MaintopicID { get; set; }


        public DateTime DateTime { get => DateTime.Now; set { } }
        public Message(string title, int userID)
        {           
            this.Title = title;
            this.UserID = userID;
        }

        public Message()
        {

        }
    }
}