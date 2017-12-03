using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using פרויקט_MVC.DAL;


namespace פרויקט_MVC.Logic
{
    public class StorageHelper
    {
        public static List<Movy> GetMovieList()
        {
            string strConnectionString = DalUtils.GetConnectionSring();
            List<Movy> listMovie = new List<Movy>();
            DataClasses1DataContext nw = new DataClasses1DataContext(strConnectionString);
            var resultQuery = from cust in nw.Movies
                              select cust;
            foreach (var item in resultQuery)
            {
                listMovie.Add(new Movy
                {
                    Id = item.Id,
                    Name =item.Name,
                    Category = item.Category
                });
            }
            return listMovie;
        }

        public static void AddNewMovieIntoTable(string MovieName, string MovieCategory)
        {
            string strConnectionString = DalUtils.GetConnectionSring();
           
            List<Movy> movyList = new List<Movy>();
            DataClasses1DataContext nw = new DataClasses1DataContext(strConnectionString);
            Movy NewMovie = new Movy
            {
                Name = MovieName,
                Category = MovieCategory
            };
            nw.Movies.InsertOnSubmit(NewMovie);
            nw.SubmitChanges();
        }


        public static List<Customer> GetCustomerList()
        {
            string strConnectionString = DalUtils.GetConnectionSring();
            List<Customer> listCustomer = new List<Customer>();

            DataClasses1DataContext nw = new DataClasses1DataContext(strConnectionString);
            var resultQuery = from cust in nw.Customers
                              select cust;
            foreach (var item in resultQuery)
            {
                listCustomer.Add(new Customer
                {
                    Id=item.Id,
                    Name = item.Name,
                    Subscription = item.Subscription,
                    Age = item.Age
                });
            }            return listCustomer;
        }

        public static void AddNewCustomerIntoTable(string CustomerName, string CustomerSelect, int CustomerAge)
        {
            //int rowsAffected;
            string strConnectionString = DalUtils.GetConnectionSring();
            DataClasses1DataContext nw = new DataClasses1DataContext(strConnectionString);
            Customer newCustomer = new Customer
            {
                Name = CustomerName,
                Subscription = CustomerSelect,
                Age = CustomerAge
            };
            nw.Customers.InsertOnSubmit(newCustomer);
            nw.SubmitChanges();
        }
        

        //public static int AddNewMovieIntoRentalTable(string UserNameRental,string MovieNameRental)
        //{
        //    string strConnectionString = DalUtils.GetConnectionSring();
        //    int rowsAffected;
        //    using (SqlConnection connection = new SqlConnection(strConnectionString))
        //    {
        //        connection.Open();
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("INSERT INTO Rentals (MovieId,CustomerId) ");
        //        sb.Append("VALUES (@movie, @customer);");
        //        String sql = sb.ToString();
        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            command.Parameters.AddWithValue("@movie", MovieNameRental);
        //            command.Parameters.AddWithValue("@customer", UserNameRental);
        //            rowsAffected = command.ExecuteNonQuery();
        //        }
        //    }
        //    return rowsAffected;
        //}
    }
}