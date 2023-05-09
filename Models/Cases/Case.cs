using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CRM_Customer_Case_Demo.Models.Customers;
using CRM_Customer_Case_Demo.Models.Agents;
using CRM_Customer_Case_Demo.Models.CaseQueues;

namespace CRM_Customer_Case_Demo.Models.Cases
{
	public class Case
	{
		public int id { get; set; }
		public string title { get; set; }
		public string state { get; set; }
		public string type { get; set; }
		public int CreatedByID { get; set; }
		[ForeignKey("CreatedByID")]
		public Customer CreatedBy { get; set; }
		public int OwnerID { get; set; }
		[ForeignKey("OwnerID")]
		public Agent Owner { get; set; }
        public int? ResolvedByID { get; set; }
        [ForeignKey("ResolvedByID")]
        public Agent ResolvedBy { get; set; }
        public int? caseQueueID { get; set; }
        [ForeignKey("caseQueueID")]
        public CaseQueue caseQueue { get; set; }
	}
}