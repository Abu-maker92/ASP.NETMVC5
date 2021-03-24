using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingManagement.Models.ViewModels
{
    public class CustomerListViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CustAccountId { get; set; }
        public string PageTitle { get; set; }
        public string AccountType { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }

        public CustAccount CustAccount { get; set; }
    }
}