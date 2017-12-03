using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using פרויקט_MVC.Logic;
using פרויקט_MVC.Models;

namespace פרויקט_MVC.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewRentals(string MovieNameRental, string UserNameRental)
        {
            bool IsSucessed = true;
            string MovieAlreadyRented = "", customerNotFound = "",
                         movieNotFound = "", RentSucsses = "";

            List<Movy> listMovie = StorageHelper.GetMovieList();
            List<Customer> listCustomer = StorageHelper.GetCustomerList();

            bool MovieExists = listMovie.Exists(item => item.Name == MovieNameRental);
            bool CustomerExist = listCustomer.Exists(item => item.Name == UserNameRental);

            int MovieId = CustomerMovieRental.GetMovieId(MovieNameRental);
            int CustomerId = CustomerMovieRental.GetCustomerId(UserNameRental);
            bool IdMovieExistInRentalTable = CustomerMovieRental.MovieIdExistInRental(MovieId);

            if (MovieNameRental == "" || UserNameRental == "")
            {
                if(MovieNameRental == "")
                {
                    movieNotFound = "Enter Movie";
                }
                if(UserNameRental == "")
                {
                    customerNotFound = "Enter Customer";
                }              
                IsSucessed = false;
            }
            else
            {
                if (!CustomerExist || !MovieExists)
                {
                    if (!CustomerExist)
                    {
                        movieNotFound = "This Movie not exist";
                        
                    }
                    if (!MovieExists)
                    {
                        customerNotFound = "This Customer not exist";
                    }
                    IsSucessed = false;
                }
                else
                {
                    if (IdMovieExistInRentalTable)
                    {
                        IsSucessed = false;
                        MovieAlreadyRented = "This movied already rented";
                    }
                    else
                    {
                        CustomerMovieRental.InsertIntoRentalTable(MovieId, CustomerId);
                        IsSucessed = true;
                        RentSucsses = "your rental sucsses";
                    }
                }
            }
            var obj = new { key = customerNotFound, key2= movieNotFound,
                            key3 = MovieAlreadyRented, key4= RentSucsses, key1 = IsSucessed };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}