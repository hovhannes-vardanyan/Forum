using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL
{
    public interface IMessage
    {
        public void Publish (IMessage msg);

        //Find Msg By id and Delete
        public void Delete(int id);

        //Find The old post or comment with by id and replace it by newMsg
        public void Edit(int id,IMessage newMsg);
    }
}
