using CRM_Customer_Case_Demo.Models.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM_Customer_Case_Demo.Controllers
{
    public class AgentController : ApiController
    {
        // GET: Customer
        static readonly IAgentRepo _AgentRepository = new AgentRepo();
        //Get All
        [HttpGet]
        public IEnumerable<Agent> GetAll()
        {
            return _AgentRepository.GetAll();
        }
        //Get by Id
        [HttpGet]

        public Agent Get(int id)
        {
            return _AgentRepository.Get(id);
        }


        [HttpPost]
        public Agent Add([FromBody] Agent _Agent)
        {
            return _AgentRepository.Post(_Agent);
        }
        //del
        [HttpDelete]
        public void Remove(int id)
        {
            _AgentRepository.Remove(id);
        }
        //patch
        [HttpPatch]
        public bool Patch([FromBody] Agent _Agent)
        {
            return _AgentRepository.Patch(_Agent);
        }
        //update
        [HttpPut]
        public string Update([FromBody] Agent _Agent)
        {
            return _AgentRepository.Put(_Agent);
        }

        ////Get by category
        //[HttpGet]
        //public async Task<IEnumerable<Customer>> GetByType(string customerType)
        //{
        //    var customers = await Task.Run(
        //        () =>
        //        CustomerRepository.GetAll()
        //        .Where(cu => string.Equals(customerType, cu.CustomerType, StringComparison.OrdinalIgnoreCase))
        //        );
        //    return customers;
        //}
        //post
    }
}