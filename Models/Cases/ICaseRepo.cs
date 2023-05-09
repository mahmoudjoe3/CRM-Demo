using CRM_Customer_Case_Demo.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Customer_Case_Demo.Models.Cases
{
    public interface ICaseRepo
    {
        //Get All
        IEnumerable<Case> GetAll();
        //Get by Id
        Case Get(int id);
        //post
        Case Post(Case item);
        //del
        void Remove(int id);
        //patch
        bool Patch(Case item);
        //update
        string Put(Case item);
        bool Assign(Case _Case, int OwnerID);
        bool Solve(Case _Case);
    }
}
