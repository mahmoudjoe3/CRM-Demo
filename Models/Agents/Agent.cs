using CRM_Customer_Case_Demo.Models.CaseQueues;
using CRM_Customer_Case_Demo.Models.Cases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM_Customer_Case_Demo.Models.Agents
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CaseQueueID { get; set; }
        [ForeignKey("CaseQueueID")]
        public CaseQueue CaseQueue { get; set; }

    }
}