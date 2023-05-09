using CRM_Customer_Case_Demo.Models.Cases;
using System.Collections.Generic;
using System.Web.Http;

namespace CRM_Customer_Case_Demo.Controllers
{
    public class CaseController : ApiController
    {
        // GET: Customer
        static readonly ICaseRepo _CaseRepository = new CaseRepo();
        //Get All
        [HttpGet]
        public IEnumerable<Case> GetAll()
        {
            return _CaseRepository.GetAll();
        }
        //Get by Id
        [HttpGet]

        public Case Get(int id)
        {
            return _CaseRepository.Get(id);
        }
        
        [HttpPost]
        public Case Add([FromBody] Case _Case)
        {
            return _CaseRepository.Post(_Case);
        }
        //del
        [HttpDelete]
        public void Remove(int id)
        {
            _CaseRepository.Remove(id);
        }
        //patch
        [HttpPatch]
        public bool Patch([FromBody] Case _Case)
        {
            return _CaseRepository.Patch(_Case);
        }
        //update
        [HttpPut]
        public string Update([FromBody] Case _Case)
        {
            return _CaseRepository.Put(_Case);
        }
        [HttpPatch]
        public bool Assign([FromBody] Case _Case, int OwnerID)
        {
            return _CaseRepository.Assign(_Case, OwnerID);
        }
        [HttpPatch]
        public bool Solve([FromBody] Case _Case)
        {
            return _CaseRepository.Solve(_Case);
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