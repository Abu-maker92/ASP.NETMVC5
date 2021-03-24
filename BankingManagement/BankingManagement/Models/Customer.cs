using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CustAccountId { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }

        public virtual CustAccount CustAccount { get; set; }
    }
}