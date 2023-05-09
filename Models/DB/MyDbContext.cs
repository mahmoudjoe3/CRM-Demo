using CRM_Customer_Case_Demo.Models.Agents;
using CRM_Customer_Case_Demo.Models.CaseQueues;
using CRM_Customer_Case_Demo.Models.Cases;
using CRM_Customer_Case_Demo.Models.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM_Customer_Case_Demo.Models.DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=myDBConnectionString"){}
        public DbSet<Customer> customers { get; set; }
        public DbSet<Case> cases { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<CaseQueue> queues { get; set; }
    }
}