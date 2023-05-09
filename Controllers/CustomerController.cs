using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using CRM_Customer_Case_Demo.Models.Customers;

namespace CRM_Customer_Case_Demo.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: Customer
        static readonly ICustomerRepo customerRepository = new CustomerRepo();
        //Get All
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }
        //Get by Id
        [HttpGet]

        public Customer Get(int id)
        {
            return customerRepository.Get(id);
        }
        //Get by category
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetByType(string customerType)
        {
            var customers = await Task.Run(
                () =>
                customerRepository.GetAll()
                .Where(cu => string.Equals(customerType, cu.CustomerType, StringComparison.OrdinalIgnoreCase))
                );
            return customers;
        }
        //post
        [HttpPost]
        public Customer Add([FromBody] Customer customer)
        {
            return customerRepository.Post(customer);
        }
        //del
        [HttpDelete]
        public void Remove(int id)
        {
            customerRepository.Remove(id);
        }
        //patch
        [HttpPatch]
        public bool Patch([FromBody] Customer customer)
        {
            return customerRepository.Patch(customer);
        }
        //update
        [HttpPut]
        public string Update([FromBody] Customer customer)
        {
            return customerRepository.Put(customer);
        }
    }
}