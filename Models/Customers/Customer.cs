using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM_Customer_Case_Demo.Models.Cases;

namespace CRM_Customer_Case_Demo.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
    }
}