using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingManagement.Models.ViewModels
{
    public class CreateCustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="Customer Name is required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Create Date is required")]
        [CurrentDateOfBirth(ErrorMessage="Create Date must be less than or today")]
        public System.DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Account Type")]
        [Required(ErrorMessage = "Account Type is required")]
        public int CustAccountId { get; set; }
        public string PageTitle { get; set; }
        public List<CustAccount> CustAccList { get; set; }
        //public string AccountType { get; set; }
        [Display(Name = "Email Address")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "Email Address is required")]
        public string Email { get; set; }
        [Range(18,99)]
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        //public CustAccount CustAccount { get; set; }
    }
}