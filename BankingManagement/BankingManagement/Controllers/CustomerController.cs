using BankingManagement.BLL.Repositories;
using BankingManagement.Models;
using BankingManagement.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerRepository repoObj = new CustomerRepository();
        public ActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? Page)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            List<CustomerListViewModel> custList = repoObj.GetCustomers();
            if (!string.IsNullOrEmpty(SearchString))
            {
                custList = custList.Where(n => n.CustomerName.ToUpper()
                .Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    custList = custList.OrderByDescending(n => n.CustomerName).ToList();
                    break;
                default:
                    custList = custList.OrderBy(n => n.CustomerName).ToList();
                    break;
            }
            int PageSize = 3;
            int PageNumber = (Page ?? 1);
            return View("Index", custList.ToPagedList(PageNumber, PageSize));
            //List<CustomerListViewModel> custList = repoObj.GetCustomers();
            //return View("Index", custList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CreateCustomerViewModel obj = new CreateCustomerViewModel();
            obj.CustAccList = repoObj.GetCustAccounts();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CreateCustomerViewModel viewObj)
        {
            var result = false;
            Customer custObj = new Customer();
            custObj.CustomerName = viewObj.CustomerName;
            custObj.CreateDate = viewObj.CreateDate;


            string filename = Path.GetFileNameWithoutExtension(viewObj.ImageFile.FileName);
            string extension = Path.GetExtension(viewObj.ImageFile.FileName);
            string fileWithExtension = filename + extension;
            custObj.ImageUrl = "~/Images/" + fileWithExtension;
            custObj.ImageName = fileWithExtension;

            string fileWithServerPath = Path.Combine(Server.MapPath("~/Images/" + filename + extension));
            viewObj.ImageFile.SaveAs(fileWithServerPath);
            custObj.CustAccountId = viewObj.CustAccountId;
            custObj.Email = viewObj.Email;
            custObj.Age = viewObj.Age;
            custObj.IsActive = viewObj.IsActive;

            if (ModelState.IsValid)
            {
                if (viewObj.CustomerId == 0)
                {
                    repoObj.SaveCustomer(custObj);
                    result = true;
                }
                else
                {
                    custObj.CustomerId = viewObj.CustomerId;
                    repoObj.UpdateCustomer(custObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.CustomerId == 0)
                {
                    return View("Create");
                }
                else
                {
                    return View("Edit");
                }

            }
        }
        public ActionResult Edit(int id)
        {
            Customer custObj = repoObj.GetCustomerById(id);
            CreateCustomerViewModel viewObj = new CreateCustomerViewModel();
            viewObj.CustomerId = custObj.CustomerId;
            viewObj.CustomerName = custObj.CustomerName;
            viewObj.CreateDate = custObj.CreateDate;
            viewObj.ImageName = custObj.ImageName;
            viewObj.ImageUrl = custObj.ImageUrl;
            viewObj.CustAccountId = custObj.CustAccountId;
            viewObj.Email = custObj.Email;
            viewObj.Age = custObj.Age;
            viewObj.IsActive = custObj.IsActive;
            viewObj.CustAccList = repoObj.GetCustAccounts();
            return View(viewObj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer custObj = repoObj.GetCustomerById(id);
            CreateCustomerViewModel viewObj = new CreateCustomerViewModel();
            viewObj.CustomerId = custObj.CustomerId;
            viewObj.CustomerName = custObj.CustomerName;
            viewObj.CreateDate = custObj.CreateDate;
            viewObj.ImageName = custObj.ImageName;
            viewObj.ImageUrl = custObj.ImageUrl;
            viewObj.CustAccountId = custObj.CustAccountId;
            viewObj.Email = custObj.Email;
            viewObj.Age = custObj.Age;
            viewObj.IsActive = custObj.IsActive;
            return View(viewObj);
        }
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Customer custObj = repoObj.GetCustomerById(id);
            if (custObj != null)
            {
                repoObj.DeleteCustomer(custObj.CustomerId);
                return RedirectToAction("Index");
            }
            return View();
        }
        public PartialViewResult Details(int CustomerId)
        {
            Customer custObj = repoObj.GetCustomerById(CustomerId);
            CustomerListViewModel viewObj = new CustomerListViewModel();
            viewObj.CustomerId = custObj.CustomerId;
            viewObj.CustomerName = custObj.CustomerName;
            viewObj.CreateDate = custObj.CreateDate;
            viewObj.ImageName = custObj.ImageName;
            viewObj.ImageUrl = custObj.ImageUrl;
            viewObj.CustAccountId = custObj.CustAccountId;
            viewObj.Email = custObj.Email;
            viewObj.Age = custObj.Age;
            viewObj.IsActive = custObj.IsActive;

            return PartialView("_DetailsRecord", viewObj);
        }
    }
}