using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingManagement.Models
{
    public class AccountInfo
    {
        public AccountInfo()
        {

        }
        [Key]
        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public virtual ICollection<CustomerInfo> CustomerInfos { get; set; }
    }
}