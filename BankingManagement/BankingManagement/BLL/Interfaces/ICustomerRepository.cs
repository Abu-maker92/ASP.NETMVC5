using BankingManagement.Models;
using BankingManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingManagement.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerListViewModel> GetCustomers();
        Customer GetCustomerById(int id);
        void SaveCustomer(Customer obj);
        void UpdateCustomer(Customer obj);
        void DeleteCustomer(int id);

        List<CustAccount> GetCustAccounts();
    }
}