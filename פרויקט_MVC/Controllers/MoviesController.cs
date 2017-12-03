using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using פרויקט_MVC.Logic;
using פרויקט_MVC.Models;

namespace פרויקט_MVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movy> listMovie = StorageHelper.GetMovieList();

            return View(listMovie);
        }

        
        public ActionResult New()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(string MovieName, string MovieCategory) //NewMovie
        {

            bool bIsValid = MovieName == ""|| MovieCategory == "" ;
            bool MovieExist = CustomerMovieRental.GetMovie(MovieName);

            if (bIsValid)
            {
                ViewBag.Error = "Enter movie name";
                return View("New");
            }
            else
            {
                if (MovieExist)//if true this movie alredy exist in the table DB
                {
                     ViewBag.Error = "This Movie alredy exist";
                     return View("New");
                }

                StorageHelper.AddNewMovieIntoTable(MovieName, MovieCategory);
          
                return RedirectToAction("Index");
            }
        }
    }
}