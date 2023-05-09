using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Customer_Case_Demo.Models.Agents
{
    public interface IAgentRepo
    {
        //Get All
        IEnumerable<Agent> GetAll();
        //Get by Id
        Agent Get(int id);
        //post
        Agent Post(Agent item);
        //del
        void Remove(int id);
        //patch
        bool Patch(Agent item);
        //update
        string Put(Agent item);
    }
}
