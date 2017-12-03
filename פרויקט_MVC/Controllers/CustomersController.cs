using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using פרויקט_MVC.Logic;

namespace פרויקט_MVC.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> listCustomer = StorageHelper.GetCustomerList();
            return View(listCustomer);
        }

        public ActionResult New()
        {
            return View(new Customer());
        }

        //[HttpPost]
     

        [HttpPost]
        public ActionResult Save(Customer cust)
        {
            bool Messages = cust.Name == "" || cust.Subscription == "" || cust.Age < 18 ;
            bool CustomerExist = CustomerMovieRental.GetCustomer(cust.Name);




            //if (ModelState.IsValid)
            //    return RedirectToAction("Index");
            //else
            //    return View("New");
        
            if (Messages)
            {
                if (cust.Name == "")
                {
                    ViewBag.EnterName = "Enter Name"; ;
                }
                if (cust.Subscription == "")
                {
                    ViewBag.EnterSubscription = "Enter Subscription";
                }
                if (cust.Age == 0)
                {
                    ViewBag.EnterAge = "Enter Age";
                }
                return View("New");
            }
            else
            {
                if (CustomerExist)// expected true if user Exist in Table
                {
                    ViewBag.UserExist = "this user alredy exist";
                    return View("New");
                }

                if (cust.Age < 18)
                {
                    ViewBag.EnterAge = "your age is less then 18";
                    return View("New");
                }
                else
                {
                    //add into Table
                    StorageHelper.AddNewCustomerIntoTable(cust.Name, cust.Subscription, cust.Age);
                }
            }
            return RedirectToAction("Index");
        }

    }
}

