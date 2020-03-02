using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_Final.Interfaces.Post_Comment
{
    public interface IMassage
    {
        public void Upload(IMassage msg);

        //Find Msg By id and Delete
        public void Delete(int id);

        //Find The old post or comment with by id and replace it by newMsg
        public void Edit(int id,IMassage newMsg);
    }
}
