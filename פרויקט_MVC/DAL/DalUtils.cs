using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace פרויקט_MVC.DAL
{
    public class DalUtils
    {
        public static string GetConnectionSring()
        {
            //string str= @"Data Source = (LocalDB)\MSSQLLocalDB; " +
            //@"AttachDbFilename =  |DataDirectory|\MoviesDB1.mdf;" +
            // "Initial Catalog = MoviesDB1;" +
            //"Integrated Security = True;";


          string str= @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\yaffa_belete\ASP.Net MVC\פרויקט_MVC\פרויקט_MVC\App_Data\MoviesDB1.mdf;"+" Integrated Security = True";
            return str;
        }
    }
}