using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Customer_Case_Demo.Models.Customers
{
    public interface ICustomerRepo
    {
        //Get All
        IEnumerable<Customer> GetAll();
        //Get by Id
        Customer Get(int id);
        //post
        Customer Post(Customer item);
        //del
        void Remove(int id);
        //patch
        bool Patch(Customer item);
        //update
        string Put(Customer item);
    }
}
