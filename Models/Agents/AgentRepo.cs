using CRM_Customer_Case_Demo.Models.CaseQueues;
using CRM_Customer_Case_Demo.Models.Customers;
using CRM_Customer_Case_Demo.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM_Customer_Case_Demo.Models.Agents
{
    public class AgentRepo : IAgentRepo
    {
        private MyDbContext _dbContext;
        private DbSet<Agent> Agents;

        public AgentRepo()
        {
            if (_dbContext == null)
                _dbContext = new MyDbContext();
            Agents = _dbContext.Agents;

        }
        public Agent Get(int id)
        {
            try
            {
                return Agents.SingleOrDefault(it => it.Id == id);
            }
            catch (Exception)
            {

                throw new Exception("GET::this id not found");
            }
        }

        public IEnumerable<Agent> GetAll()
        {
            if (Agents == null)
                return new List<Agent>();
            
            return Agents;
        }

        public bool Patch(Agent _Agent)
        {
            if (_Agent == null)
            {
                throw new ArgumentNullException($"{_Agent} is null");
            }
            Agent cu = Agents.SingleOrDefault(i => i.Id == _Agent.Id);

            if (cu == null)
                return false;

            if (!string.IsNullOrEmpty(_Agent.Name))
                cu.Name = _Agent.Name;
            if (!(_Agent.CaseQueueID is null))
                cu.CaseQueueID = _Agent.CaseQueueID;

            _dbContext.SaveChanges();
            return true;
        }

        public Agent Post(Agent _Agent)
        {
            if (_Agent == null)
            {
                throw new ArgumentNullException($"{_Agent} is null");
            }
            CaseQueue cq = _dbContext.queues.SingleOrDefault(q => q.id == _Agent.CaseQueueID);
            if (cq == null) throw new Exception("CaseQueue not found with this id");
            _Agent.CaseQueue= cq;
            Agents.Add(_Agent);
            _dbContext.SaveChanges();
            return _Agent;
        }

        public string Put(Agent _Agent)
        {
            if (_Agent == null)
            {
                throw new ArgumentNullException($"{_Agent} is null");
            }
            Agent cu = Agents.SingleOrDefault(i => i.Id == _Agent.Id);

            if (cu == null)
            {
                Agents.Add(_Agent);
                return "item created";
            }
            Agents.Remove(Agents.SingleOrDefault(i => i.Id == _Agent.Id));
            Agents.Add(_Agent);
            _dbContext.SaveChanges();
            return "item updated";
        }

        public void Remove(int id)
        {
            try
            {
                Agents.Remove(Agents.SingleOrDefault(i => i.Id == id));
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("REMOVE::this id not found");
            }
        }
    }
}