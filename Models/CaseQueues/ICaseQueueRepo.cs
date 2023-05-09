using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Customer_Case_Demo.Models.CaseQueues
{
    public interface ICaseQueueRepo
    {
        //Get All
        IEnumerable<CaseQueue> GetAll();
        //Get by Id
        CaseQueue Get(int id);
        //post
        CaseQueue Post(CaseQueue item);
        //del
        void Remove(int id);
        //patch
        bool Patch(CaseQueue item);
        //update
        string Put(CaseQueue item);
    }
}
