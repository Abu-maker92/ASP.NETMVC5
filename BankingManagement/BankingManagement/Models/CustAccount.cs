using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingManagement.Models
{
    public class CustAccount
    {
        public CustAccount()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string AccountType { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}