using CRM_Customer_Case_Demo.Models.Cases;
using CRM_Customer_Case_Demo.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM_Customer_Case_Demo.Models.Customers
{
    public class CustomerRepo : ICustomerRepo
    {
        private MyDbContext _dbContext;
        private DbSet<Customer> customers;

        public CustomerRepo()
        {
            if(_dbContext == null)
                _dbContext = new MyDbContext();
            customers = _dbContext.customers;
            if (customers == null || customers.Count() == 0)
            {
                Post(new Customer { Name = "MahmoudElazizi", CustomerType = "premium" });
                Post(new Customer { Name = "Amr", CustomerType = "silver" });
                Post(new Customer { Name = "ebrahim", CustomerType = "gold" });

            }
        }
        public Customer Get(int id)
        {
            try
            {
                return customers.SingleOrDefault(customer => customer.Id == id);
            }
            catch (Exception)
            {

                throw new Exception("GET::this id not found");
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            if(customers==null)
                return new List<Customer>();
            return customers;
        }

        public bool Patch(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("item");
            }
            Customer cu = customers.SingleOrDefault(i => i.Id == customer.Id);

            if (cu == null)
                return false;

            if (!string.IsNullOrEmpty(customer.Name))
                cu.Name = customer.Name;
            if (!string.IsNullOrEmpty(customer.CustomerType))
                cu.CustomerType = customer.CustomerType;
            _dbContext.SaveChanges();
            return true;
        }

        public Customer Post(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            
            customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public string Put(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }
            Customer cu = customers.SingleOrDefault(i => i.Id == customer.Id);

            if (cu == null)
            {
                customers.Add(customer);
                return "customer created";
            }
            customers.Remove(customers.SingleOrDefault(i => i.Id == customer.Id));
            customers.Add(customer);
            _dbContext.SaveChanges();
            return "customer updated";
        }

        public void Remove(int id)
        {
            try
            {
                customers.Remove(customers.SingleOrDefault(i => i.Id == id));
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("REMOVE::this id not found");
            }
        }
    }
}