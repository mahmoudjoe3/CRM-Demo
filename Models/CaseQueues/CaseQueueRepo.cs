using CRM_Customer_Case_Demo.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM_Customer_Case_Demo.Models.CaseQueues
{
    public class CaseQueueRepo : ICaseQueueRepo
    {
        private MyDbContext _dbContext;
        private DbSet<CaseQueue> CaseQueues;

        public CaseQueueRepo()
        {
            if (_dbContext == null)
                _dbContext = new MyDbContext();
            CaseQueues = _dbContext.queues;

        }
        public CaseQueue Get(int id)
        {
            try
            {
                return CaseQueues.SingleOrDefault(it => it.id == id);
            }
            catch (Exception)
            {

                throw new Exception("GET::this id not found");
            }
        }

        public IEnumerable<CaseQueue> GetAll()
        {
            if (CaseQueues == null)
                return new List<CaseQueue>();
            return CaseQueues;
        }

        public bool Patch(CaseQueue _CaseQueue)
        {
            if (_CaseQueue == null)
            {
                throw new ArgumentNullException($"{_CaseQueue} is null");
            }
            CaseQueue cu = CaseQueues.SingleOrDefault(i => i.id == _CaseQueue.id);

            if (cu == null)
                return false;

            _dbContext.SaveChanges();
            return true;
        }

        public CaseQueue Post(CaseQueue _CaseQueue)
        {
            if (_CaseQueue == null)
            {
                throw new ArgumentNullException($"{_CaseQueue} is null");
            }
            CaseQueues.Add(_CaseQueue);
            _dbContext.SaveChanges();
            return _CaseQueue;
        }

        public string Put(CaseQueue _CaseQueue)
        {
            if (_CaseQueue == null)
            {
                throw new ArgumentNullException($"{_CaseQueue} is null");
            }
            CaseQueue cu = CaseQueues.SingleOrDefault(i => i.id == _CaseQueue.id    );

            if (cu == null)
            {
                CaseQueues.Add(_CaseQueue);
                return "item created";
            }
            CaseQueues.Remove(CaseQueues.SingleOrDefault(i => i.id == _CaseQueue.id));
            CaseQueues.Add(_CaseQueue);
            _dbContext.SaveChanges();
            return "item updated";
        }

        public void Remove(int id)
        {
            try
            {
                CaseQueues.Remove(CaseQueues.SingleOrDefault(i => i.id == id));
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("REMOVE::this id not found");
            }
        }
    }
}