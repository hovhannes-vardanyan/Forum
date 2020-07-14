using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ForumDAL
{
    public abstract class Message
    {
        public int PostID { get; set; }
        [Required(ErrorMessage = "Enter the title")]
        public string Title { get; set; }
        [Required]

        public int UserID { get; set; }
        [Required]

        public int SubtopicID { get; set; }
        [Required]

        public int MaintopicID { get; set; }


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