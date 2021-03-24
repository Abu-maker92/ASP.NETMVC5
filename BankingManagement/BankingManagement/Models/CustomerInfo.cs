using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingManagement.Models
{
    public class CustomerInfo
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DoB { get; set; }
        public string Occupation { get; set; }
        public decimal Salary { get; set; }
        public int AccountId { get; set; }
        public virtual AccountInfo AccountInfo { get; set; }
    }
}