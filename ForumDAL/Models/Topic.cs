using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public abstract class Topic
    {
        public int SubtopicID { get; set; }

        public int MaintopicID { get; set; }
    }
}