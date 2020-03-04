using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL
{
    public interface IMessage<T> 
    {
         void Publish (T msg);

        //Find Msg By id and Delete
         void Delete(int id);

        //Find The old post or comment with by id and replace it by newMsg
         void Edit(int id,T newMsg);
    }
}
