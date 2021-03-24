using BankingManagement.BLL.Interfaces;
using BankingManagement.Models;
using BankingManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingManagement.BLL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void DeleteCustomer(int id)
        {
            Customer delObj = GetCustomerById(id);
            db.Customers.Remove(delObj);
            db.SaveChanges();
        }

        public List<CustAccount> GetCustAccounts()
        {
            List<CustAccount> custaccList = db.CustAccounts.ToList();
            return custaccList;
        }

        public Customer GetCustomerById(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(p => p.CustomerId == id);
            return obj;
        }

        public List<CustomerListViewModel> GetCustomers()
        {
            List<CustomerListViewModel> viewlist = new List<CustomerListViewModel>();
            List<Customer> list = db.Customers.ToList();
            viewlist = db.Customers.Select(p => new CustomerListViewModel
            {
                CustomerId = p.CustomerId,
                CustomerName = p.CustomerName,
                CreateDate = p.CreateDate,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                CustAccountId = p.CustAccountId,
                AccountType = p.CustAccount.AccountType,
                Email = p.Email,
                Age = p.Age,
                IsActive = p.IsActive,
                PageTitle = "Customer List",

            }).ToList();
            return viewlist;
        }

        public void SaveCustomer(Customer obj)
        {
            db.Customers.Add(obj);
            db.SaveChanges();
        }

        public void UpdateCustomer(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}