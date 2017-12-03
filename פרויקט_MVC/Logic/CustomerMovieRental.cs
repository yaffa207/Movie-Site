using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using פרויקט_MVC.DAL;
using פרויקט_MVC.Models;

namespace פרויקט_MVC.Logic
{
    public class CustomerMovieRental
    {
        public static int GetMovieId(string MovieName)
        {
            int idNum = 0;
            ;
            foreach (var item in StorageHelper.GetMovieList())
            {
                if(item.Name == MovieName)
                {
                    idNum = item.Id;
                }
            }
            return idNum;
        }

        public static int GetCustomerId(string CustomerName)
        {
            int idNum = 0;
            foreach (var item in StorageHelper.GetCustomerList())
            {
                if (item.Name == CustomerName)
                {
                    idNum = item.Id;
                }
            }
            return idNum;
        }

        //movieId Exist in RentalTable
        public static bool MovieIdExistInRental(int movieID)
        {
            string strConnectionString = DalUtils.GetConnectionSring();
            List<Rental> listRent = new List<Rental>();
            DataClasses1DataContext nw = new DataClasses1DataContext(strConnectionString);
            var resultQuery = from rent in nw.Rentals
                              select rent;
            foreach (var item in resultQuery)
            {
                listRent.Add(new Rental
                {
                    MovieId = item.MovieId,
                    CustomerId = item.CustomerId
                });
            }
            bool IdMovieExistInRental = listRent.Exists(item => item.MovieId == movieID);
            return IdMovieExistInRental;    
        }

        //add if movie not rented
        public static void InsertIntoRentalTable(int MovieId, int CustomerId)
        {
            string strConnectionString = DalUtils.GetConnectionSring();
            DataClasses1DataContext nw = new DataClasses1DataContext(strConnectionString);
            Rental newRental = new Rental();
            newRental.MovieId = MovieId;
            newRental.CustomerId = CustomerId;
            nw.Rentals.InsertOnSubmit(newRental);
            nw.SubmitChanges();
        }

        public static bool GetCustomer(string CustomerName)
        {
            string strConnectionString = DalUtils.GetConnectionSring();
            List<Customer> listCustomer = StorageHelper.GetCustomerList();

            bool UserExist = listCustomer.Exists(item => item.Name == CustomerName);
            return UserExist;
        }

        public static bool GetMovie(string MovieName)
        {
            List<Movy> listMovie = StorageHelper.GetMovieList();
            bool MovieExist = listMovie.Exists(item => item.Name == MovieName);
            // this Movie exzist ?
            return MovieExist;
        }
    }
}