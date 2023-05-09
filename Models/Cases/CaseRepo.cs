using CRM_Customer_Case_Demo.Models.Agents;
using CRM_Customer_Case_Demo.Models.Customers;
using CRM_Customer_Case_Demo.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace CRM_Customer_Case_Demo.Models.Cases
{
    public class CaseRepo : ICaseRepo
    {
        private MyDbContext _dbContext;
        private DbSet<Case> Cases;

        public CaseRepo()
        {
            if (_dbContext == null)
                _dbContext = new MyDbContext();
            Cases = _dbContext.cases;

        }
        public Case Get(int id)
        {
            try
            {
                return Cases.SingleOrDefault(it => it.id == id);
            }
            catch (Exception)
            {

                throw new Exception("GET::this id not found");
            }
        }

        public IEnumerable<Case> GetAll()
        {
            if (Cases == null)
                return new List<Case>();
            return Cases;
        }

        public bool Patch(Case _Case)
        {
            if (_Case == null)
            {
                throw new ArgumentNullException($"{_Case} is null");
            }
            if (_Case.CreatedBy is null)
            {
                throw new ArgumentNullException($"{_Case} creator should not be null");
            }
            if (_Case.Owner is null)
            {
                throw new ArgumentNullException($"{_Case} Owner should not be null");
            }
            Case cu = Cases.SingleOrDefault(i => i.id == _Case.id);

            if (cu == null)
                return false;

            if (!string.IsNullOrEmpty(_Case.title))
                cu.title = _Case.title;
            if (!string.IsNullOrEmpty(_Case.state))
                cu.state = _Case.state;
            if (!string.IsNullOrEmpty(_Case.type))
                cu.type = _Case.type;
            if (!(_Case.caseQueueID is null))
                cu.caseQueueID = _Case.caseQueueID;
            
            _dbContext.SaveChanges();
            return true;
        }

        public bool Assign(Case _Case,int OwnerID)
        {
            if (_Case == null)
            {
                throw new ArgumentNullException($"{_Case} is null");
            }
            
            Case cu = Cases.SingleOrDefault(i => i.id == _Case.id);
            cu.OwnerID = OwnerID;
            if (cu == null)
                return false;

            if (!string.IsNullOrEmpty(_Case.title))
                cu.title = _Case.title;
            if (!string.IsNullOrEmpty(_Case.state))
                cu.state = _Case.state;
            if (!string.IsNullOrEmpty(_Case.type))
                cu.type = _Case.type;
            Agent ag = _dbContext.Agents.SingleOrDefault(i => i.Id == OwnerID);
            if (ag == null)
                throw new ArgumentNullException($"{OwnerID} should not be null");
            cu.caseQueueID = ag.CaseQueueID;
            _dbContext.SaveChanges();
            return true;
        }

        public bool Solve(Case _Case)
        {
            if (_Case == null)
            {
                throw new ArgumentNullException($"{_Case} is null");
            }
            
            Case cu = Cases.SingleOrDefault(i => i.id == _Case.id);
            cu.ResolvedByID = _Case.OwnerID;
            if (cu == null)
                return false;

            if (!string.IsNullOrEmpty(_Case.title))
                cu.title = _Case.title;
            if (!string.IsNullOrEmpty(_Case.state))
                cu.state = _Case.state;
            if (!string.IsNullOrEmpty(_Case.type))
                cu.type = _Case.type;
            if (!(_Case.caseQueueID is null))
                cu.caseQueueID = _Case.caseQueueID;

            _dbContext.SaveChanges();
            return true;
        }

        public Case Post(Case ca)
        {
            Customer customer = _dbContext.customers.SingleOrDefault(c => c.Id == ca.CreatedByID);
            if (customer == null) throw new Exception("customer not found with this id");

            Agent agent = _dbContext.Agents.SingleOrDefault(c => c.Id == ca.OwnerID);
            if (agent == null) throw new Exception("Agent not found with this id");
            //ca.CreatedBy = customer;
            //ca.Owner = agent;
            Cases.Add(ca);
            _dbContext.SaveChanges();
            return ca;
        }

        public string Put(Case _Case)
        {
            if (_Case == null)
            {
                throw new ArgumentNullException($"{_Case} is null");
            }
            Case cu = Cases.SingleOrDefault(i => i.id == _Case.id);

            if (cu == null)
            {
                Cases.Add(_Case);
                return "item created";
            }
            Cases.Remove(Cases.SingleOrDefault(i => i.id == _Case.id));
            Cases.Add(_Case);
            _dbContext.SaveChanges();
            return "item updated";
        }

        public void Remove(int id)
        {
            try
            {
                Cases.Remove(Cases.SingleOrDefault(i => i.id == id));
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("REMOVE::this id not found");
            }
        }
    }
}