using CRM_Customer_Case_Demo.Models.CaseQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM_Customer_Case_Demo.Controllers
{
    public class CaseQueueController : ApiController
    {
        // GET: Customer
        static readonly ICaseQueueRepo _CaseQueueRepository = new CaseQueueRepo();
        //Get All
        [HttpGet]
        public IEnumerable<CaseQueue> GetAll()
        {
            return _CaseQueueRepository.GetAll();
        }
        //Get by Id
        [HttpGet]

        public CaseQueue Get(int id)
        {
            return _CaseQueueRepository.Get(id);
        }


        [HttpPost]
        public CaseQueue Add([FromBody] CaseQueue _CaseQueue)
        {
            return _CaseQueueRepository.Post(_CaseQueue);
        }
        //del
        [HttpDelete]
        public void Remove(int id)
        {
            _CaseQueueRepository.Remove(id);
        }
        //patch
        [HttpPatch]
        public bool Patch([FromBody] CaseQueue _CaseQueue)
        {
            return _CaseQueueRepository.Patch(_CaseQueue);
        }
        //update
        [HttpPut]
        public string Update([FromBody] CaseQueue _CaseQueue)
        {
            return _CaseQueueRepository.Put(_CaseQueue);
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