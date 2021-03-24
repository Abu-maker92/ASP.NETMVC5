using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace BankingManagement.Models.ViewModels
{
    internal class CurrentDateOfBirthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}