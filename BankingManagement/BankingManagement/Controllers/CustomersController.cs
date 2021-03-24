using BankingManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BankingManagement.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                List<AccountInfo> customerAndAccount = db.AccountInfos.Include("CustomerInfos").ToList();
                return View(customerAndAccount);
            }
        }
        [HttpGet]
        public ActionResult GetAllAccount()
        {

            return Json(db.AccountInfos.Select(x => new
            {
                AccountId = x.AccountId,
                AccountType = x.AccountType
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveCustomer(string name, CustomerInfo[] customer)
        {
            using (var db = new ApplicationDbContext())
            {
                string result = "Error! Customer Is Not Complete!";
                if (name != null && customer != null)
                {
                    //var GradeId = Guid.NewGuid();
                    AccountInfo model = new AccountInfo();

                    model.AccountType = name;
                    db.AccountInfos.Add(model);

                    foreach (var item in customer)
                    {
                        //var PlayerId = Guid.NewGuid();
                        CustomerInfo O = new CustomerInfo();

                        O.Name = item.Name;
                        O.Email = item.Email;
                        O.Phone = item.Phone;
                        O.DoB = item.DoB;
                        O.Occupation = item.Occupation;
                        O.Salary = item.Salary;
                        O.AccountId = item.AccountId;
                        db.CustomerInfos.Add(O);
                    }
                    db.SaveChanges();
                    result = "Success! Customer Is Complete!";
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult EditCustomer(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                CustomerInfo customer = db.CustomerInfos.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CustomerId = new SelectList(db.AccountInfos, "AccountId", "AccountType", customer.AccountId);
                return View(customer);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CustomerId,Name,Email,Phone,DoB,Occupation,Salary,AccountId")] CustomerInfo customer)
        {
            using (var db = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CustomerId = new SelectList(db.AccountInfos, "AccountId", "AccountType", customer.AccountId);
                return View(customer);
            }

        }
        public ActionResult EditAccount(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                AccountInfo acc = db.AccountInfos.Find(id);
                if (acc == null)
                {
                    return HttpNotFound();
                }

                return View(acc);
            }


        }
    }
}