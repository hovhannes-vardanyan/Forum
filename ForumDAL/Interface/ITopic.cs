using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Interface
{
    public interface ITopic<T>
    {
        void AddTopic(T adder);
        void RemoveTopic(T remover);

    }
}
